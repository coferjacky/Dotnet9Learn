namespace _393ThreadExample
{
    class NumbersCounter
    {
        public void CountUp()
        {
            for (int i = 0; i < 100; i++)
            {
                System.Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"i={i}, ");
            }
        }

        public void CountDown()
        {
            for (int j = 100; j>= 1; j--)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"j={j}, ");
            }
        }
    }
    
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Thread mainThread=Thread.CurrentThread;
            mainThread.Name = "Main thread";
            Console.WriteLine(mainThread.Name);

            NumbersCounter numbersCounter = new NumbersCounter();
            numbersCounter.CountUp();
            numbersCounter.CountDown();

            Console.WriteLine(mainThread.Name+" complete");
            
        }
    }
}
