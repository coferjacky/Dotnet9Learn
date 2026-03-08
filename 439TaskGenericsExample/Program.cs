using System.Net.Http.Headers;

namespace _439TaskGenericsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UpCounter upCount = new UpCounter();
            DownCounter downCount = new DownCounter();
            Task<long> task1 = Task.Run(() => {
               return upCount.CountUp(20);
                
            });
            Task<long> task2 = Task.Factory.StartNew(() => {
                return downCount.CountDown(20);
            });

            Task.WaitAll(task1,task2);
            Console.WriteLine($"Result from Count-up:{task1.Result}");
            Console.WriteLine($"Result from Count-up:{task2.Result}");
            Console.ReadKey();
        }
    }
    class UpCounter
    {
        public long CountUp(int count)
        {
            long sum = 0;
            Console.WriteLine("\nCount-up start");
            for (int i = 1; i < count; i++)
            {
                Console.Write($"i={i}, ");
                sum += i;
            }
            Console.WriteLine("\nCount-up end");
            return sum;


        }
    }

    class DownCounter
    {
        public long CountDown(int count)
        {
            long sum= 0;
            Console.WriteLine("\nCount-down start");
            for (int i = count; i >= 1; i--)
            {
                Console.Write($"j={i}, ");
                sum+= i;    
            }
            Console.WriteLine("\nCount-down end");
            return sum;
                 
        }
    }
}
