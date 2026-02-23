
using System.Collections.Concurrent;
using System.Reflection.PortableExecutable;

namespace _418ConcurrentQueueExample
{
    //改写416

    static class Shared
    {
        public static Object LockObject = new Object();
        //public static Queue<int> Buffer = new Queue<int>();
        public static ConcurrentQueue<int> Buffer=new ConcurrentQueue<int>();
        public const int BufferCapcity = 5;

        //+ 事件手工重置的
        public static ManualResetEvent ProducerEvent = new ManualResetEvent(true);

        public static ManualResetEvent ConsumerEvent = new ManualResetEvent(false);


        public static void Print()
        {
            Console.Write("in Buffer are: ");
            foreach (int item in Buffer)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
        }


    }
    //生产者
    class Producer
    {
        public void Produce()
        {
            Console.WriteLine("Produce： Generating Data");
            Thread.Sleep(7000); //7s
            for (int i = 0; i < 10; i++)
            {
                /*lock (Shared.LockObject)
                {*/

                    if (Shared.Buffer.Count == Shared.BufferCapcity)
                    {
                        Console.WriteLine("buffer is full, wait for signal from consumer");
                        //Monitor.Wait(Shared.LockObject); //wait for signal from consumer thread
                        Shared.ProducerEvent.Reset(); //set the state 未触发状态


                    }
                /*}*/

                Shared.ProducerEvent.WaitOne(); //这里阻塞

               /* lock (Shared.LockObject)
                {*/
                    Shared.Buffer.Enqueue(i);
                    Console.WriteLine($"Productor produced :{i}");
                    Shared.Print();

                    //通知消费者我已经生成好了,脉冲函数唤醒消费者的线程
                    //Monitor.Pulse(Shared.LockObject);
                    Shared.ConsumerEvent.Set(); //通知消费者我已经生成通知消费者我已经生成好了,唤醒消费者的线程
                /*}*/


            }
            Console.WriteLine("production is over");
        }
    }
    //消费者
    class Consumer
    {
        public void Consume()
        {
            Console.WriteLine("Consumer is begin");
            for (int i = 0; i < 10; i++)
            {
               /* lock (Shared.LockObject)
                {*/
                    //缓冲区为空，消费者被迫等待                   
                    if (Shared.Buffer.Count == 0)
                    {
                        Console.WriteLine("buffer is empty, wait....");
                        //Monitor.Wait(Shared.LockObject);
                        Shared.ConsumerEvent.Reset(); //消费者事件变成 未触发 信号状态
                    }
                /*}*/

                Shared.ConsumerEvent.WaitOne(); //这里开始阻塞
                //模拟消费 2.5秒
                Console.WriteLine("Consumer:Processing Data");
                Thread.Sleep(2500);
               /* lock (Shared.LockObject)
                {*/
                    bool isSuccess= Shared.Buffer.TryDequeue(out int val);
                if(isSuccess)
                {
                    Console.WriteLine($"Connsumer consumed:{val}");
                }
                else
                {
                    Console.WriteLine("fail read from queue");
                }
                    

                    //通知缓冲区有空位了,这是脉冲方法,通知生产者
                    //Monitor.Pulse(Shared.LockObject);
                    Shared.ProducerEvent.Set(); //将生产者状态调整未signal状态
               /* }*/
            }
            Console.WriteLine("Consumertion is over");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Producer producer = new Producer();
            Consumer consumer = new Consumer();

            Thread proThread = new Thread(producer.Produce)
            {
                Name = "produce Thread"

            };
            Thread conThread = new Thread(consumer.Consume)
            {
                Name = "Consume Thread"
            };

            proThread.Start();
            conThread.Start();

            proThread.Join();
            conThread.Join();

            Console.WriteLine("MAIN THREAD OVER");

        }
    }
}
