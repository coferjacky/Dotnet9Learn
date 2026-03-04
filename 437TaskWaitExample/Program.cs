using System.Net.Http.Headers;

namespace _437TaskWaitExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UpCounter upCount = new UpCounter();
            DownCounter downCount = new DownCounter();
            Task task1 = Task.Factory.StartNew(() => {
                upCount.CountUp(20);
            });
            Task task2 = Task.Factory.StartNew(() => {
                downCount.CountDown(20);
            });
            //等待任务1和任务2完成。阻塞当前线程执行
            /*task1.Wait();
            task2.Wait();*/

            Task.WaitAll(task1,task2); //这两个task对象自动转成数组
            Console.ReadKey();
        }
    }
    class UpCounter
    {
        public void CountUp(int count)
        {
            Console.WriteLine("\nCount-up start");
            for (int i = 1; i < count; i++)
            {
                Console.Write($"i={i}, ");
            }
            Console.WriteLine("\nCount-up end");
        }
    }

    class DownCounter
    {
        public void CountDown(int count)
        {
            Console.WriteLine("\nCount-down start");
            for (int i = count; i >= 1; i--)
            {
                Console.Write($"j={i}, ");
            }
            Console.WriteLine("\nCount-down end");
        }
    }
}
