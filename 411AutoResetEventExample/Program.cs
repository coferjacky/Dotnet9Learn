namespace _411AutoResetEventExample
{
    /**
      * 模拟生产者生产数组数据后，消费者在生产完毕后开始消费     * 
      */
    class Shared
    {
        public static int[] Data { get; set; }
        public static int BatchCount { get; set; }

        public static int BatchSize { get; set; }

        //1 创建手动重置对象的对象
        public static AutoResetEvent Event { get; set; }

        static Shared()
        {
            Data = new int[15];
            //每一批次生产3个数值，一共分5个批次
            BatchCount = 5;
            BatchSize = 3;
            //2 .默认手动重置对象为未触发,默认情况下，销售者线程必须等待，直到生产者将信号设置为true
            Event = new AutoResetEvent(false);
        }
    }

    class Producer
    {
        public void Produce()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} started");
            for (int i = 0; i < Shared.BatchCount; i++) //5 time
            {
                for (int j = 0; j < Shared.BatchSize; j++) //3 time
                {
                    //生产数据到数组里面
                    Shared.Data[i * Shared.BatchSize + j] = (i * Shared.BatchSize) + j + 1;  //1 to 15
                    Thread.Sleep(300);
                }


                //4. 发出信号告知消费者线程 状态设置为true
                Shared.Event.Set();

                //5. 一批次完成后，对EventReset,让消费者继续等待 自动Reset事件就不用这句
                //Shared.Event.Reset();
            }


            Console.WriteLine($"{Thread.CurrentThread.Name} completed");
        }
    }
    class Consumer
    {
        public void Consume()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} started");
            for (int i = 0; i < Shared.BatchCount; i++)
            {
                //3. 线程先让他先等待 阻塞语句，直到变成true;
                Shared.Event.WaitOne();
                //5 步骤四true以后，就是通知线程从这里可以执行了
                Console.WriteLine("Consumer has received a signal from Producer");
                for (int j = 0; j < Shared.BatchSize; j++)
                {
                    Console.WriteLine("consumer begin:" + Shared.Data[i * Shared.BatchSize + j]);
                }
            }
            Console.WriteLine($"{Thread.CurrentThread.Name} completed");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Consumer cust = new Consumer();
            Producer producer = new Producer();

            ThreadStart threadStart1 = new ThreadStart(producer.Produce);
            ThreadStart threadStart2 = new ThreadStart(cust.Consume);

            Thread producerThread = new Thread(threadStart1) { Name = "Producer Thread" };
            Thread consumerThread = new Thread(threadStart2) { Name = "Consumer Thread" };


            producerThread.Start();
            consumerThread.Start();


            producerThread.Join();
            consumerThread.Join();
        }
    }
}
