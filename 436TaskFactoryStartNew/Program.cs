using System.Net.Http.Headers;

namespace _436TaskFactoryStartNew
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

            //上面代码Task.Run()方法会立即执行委托中的代码，并返回一个Task对象并自动启动它，你省去了调用Start()方法的麻烦。
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
