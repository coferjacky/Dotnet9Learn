using System.Net.Http.Headers;

namespace _442TaskDelay
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
            //等待task1或task2完成,已完成就调用当前的线程继续执行
            int firstid = Task.WaitAny(task1, task2);
            if (firstid == 0)
            {
                Console.WriteLine($"Result from Count-up:{task2.Result.Sum}");
            }
            else
            {
                Console.WriteLine($"Result from Count-down:{task2.Result.Sum}");
            }


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
                //我模拟一个耗时的操作，每隔几秒输出1个数字,谁调用这个方法，谁就会被阻塞
                //现实世界项目中，可能是一个耗时的计算，或者是一个IO操作，或者是一个网络请求等，要避免
                Task.Delay(1300).Wait();

            }
            Console.WriteLine("\nCount-up end");
            return new SumData() { Sum = sum };


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
