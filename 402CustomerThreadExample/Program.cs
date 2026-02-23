namespace _402CustomerThreadExample
{
   
    class NumbersUpCounter
    {
        public int Count { get; set; }
        public void CountUp()
        {
            try
            {
                Console.WriteLine("Cu start");
                Thread.Sleep(100);
                
                for (int? i = 0; i < Count; i++)
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
    }


    class NumbersDownCounter
    {
        public int Count { get; set; }
        public void CountDown()
        {
           
            Console.WriteLine("Cd start");
            Thread.Sleep(100);
            for (int? j = Count; j >= 1; j--)
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

            NumbersUpCounter numbersUpCounter = new NumbersUpCounter() { Count=100};

            //1.创建委托对象
            ThreadStart threadstart1 = new ThreadStart(
                numbersUpCounter.CountUp
            );
            //2. 创建线程对象
            Thread thread1 = new Thread(threadstart1)
            {

                Name = "thread1--",
                Priority = ThreadPriority.Normal

            };

            ;
            //3. 启动线程            
            thread1.Start();

            Console.WriteLine($"{thread1.Name} is {thread1.ThreadState.ToString()}");

            //创建第二个线程
            NumbersDownCounter numbersDownCounter = new NumbersDownCounter() { Count = 100 };
            //1.创建第二个委托对象
            ThreadStart threadstart2 = new ThreadStart(numbersDownCounter.CountDown);
            //2. 创建线程对象
            Thread thread2 = new Thread(threadstart2);
            thread2.Name = "thread2--";
            //3. 设置优先级
            thread2.Priority = ThreadPriority.Highest;
            //4. 启动线程
            
            thread2.Start();

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
