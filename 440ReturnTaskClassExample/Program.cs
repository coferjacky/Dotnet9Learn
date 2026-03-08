using System.Net.Http.Headers;

namespace _440ReturnTaskClassExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UpCounter upCount = new UpCounter();
            DownCounter downCount = new DownCounter();
            Task<SumData> task1 = Task.Run(() => {
                return upCount.CountUp(20);
            });
            Task<SumData> task2 = Task.Factory.StartNew(() => {
                return downCount.CountDown(20);
            });
            //等待所有任务完成
            Task.WaitAll(task1, task2);
            Console.WriteLine($"Result from Count-up:{task1.Result.Sum}");
            Console.WriteLine($"Result from Count-up:{task2.Result.Sum}");
            Console.ReadKey();
        }
    }
    class UpCounter
    {
        public SumData CountUp(int count)
        {
            long sum = 0;
            Console.WriteLine("\nCount-up start");
            for (int i = 1; i < count; i++)
            {
                Console.Write($"i={i}, ");
                sum += i;
            }
            Console.WriteLine("\nCount-up end");
            return new SumData() { Sum=sum};


        }
    }

    class DownCounter
    {
        public SumData CountDown(int count)
        {
            long sum = 0;
            Console.WriteLine("\nCount-down start");
            for (int i = count; i >= 1; i--)
            {
                Console.Write($"j={i}, ");
                sum += i;
            }
            Console.WriteLine("\nCount-down end");
            return new SumData() { Sum = sum };

        }
    }

    //设置一个类
    class SumData
    {
       public long Sum { get; set; }    
    }
}
