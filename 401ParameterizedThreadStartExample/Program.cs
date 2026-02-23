using System.Threading;

namespace _401ParameterizedThreadStartExample
{
      
    class MaxCount
    {
        public int Count { get; set;}
    }
    class NumbersCounter
    {

        public void CountUp(Object? count)
        {
            try
            {
                Console.WriteLine("Cu start");
                Thread.Sleep(100);
                MaxCount? maxCount = (MaxCount?)count;
                if (maxCount == null)
                {
                    return;
                }
                for (int? i = 0; i < maxCount.Count; i++)
                {
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"i={i}, ");
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);
                Console.WriteLine("Cu end");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }


        }

        public void CountDown(object? count)
        {
            MaxCount? countInt = (MaxCount?)count;
            if(countInt == null)
            {
                return;
            }
            Console.WriteLine("Cd start");
            Thread.Sleep(100);
            for (int? j = countInt.Count; j >= 1; j--)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"j={j}, ");
                Thread.Sleep(100);
            }
            Thread.Sleep(100);
            Console.WriteLine("Cd end");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thread mainThread = Thread.CurrentThread;
            mainThread.Name = "Main thread";
            Console.WriteLine(mainThread.Name + " start");

            NumbersCounter numbersCounter = new NumbersCounter();
            
            //1.创建委托对象
            ParameterizedThreadStart threadstart1 = new ParameterizedThreadStart(
                numbersCounter.CountUp
            );
            //2. 创建线程对象
            Thread thread1 = new Thread(threadstart1)
            {

                Name = "thread1--",
                Priority = ThreadPriority.Normal

            };

            ;
            //3. 启动线程
            MaxCount maxCount = new MaxCount() { Count = 100 };
            thread1.Start(maxCount);

            Console.WriteLine($"{thread1.Name} is {thread1.ThreadState.ToString()}");

            //创建第二个线程
            //1.创建第二个委托对象
            ParameterizedThreadStart threadstart2 = new ParameterizedThreadStart(numbersCounter.CountDown);
            //2. 创建线程对象
            Thread thread2 = new Thread(threadstart2);
            thread2.Name = "thread2--";
            //3. 设置优先级
            thread2.Priority = ThreadPriority.Highest;
            //4. 启动线程
            MaxCount maxCount2 = new MaxCount() { Count = 100 };
            thread2.Start(maxCount2);

            Console.WriteLine($"{thread2.Name} is {thread2.ThreadState.ToString()}");
            //numbersCounter.CountDown();

            //join
            thread1.Join();
            //Console.WriteLine($"Main thread+{mainThread.ThreadState}");
            thread2.Join();




            Console.WriteLine(mainThread.Name + " complete");

        }
    }
}
