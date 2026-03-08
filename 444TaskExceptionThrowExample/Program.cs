using System.Net.Http.Headers;

namespace _444TaskExceptionThrowExample
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
            Task continuationTask1 = task1.ContinueWith((antecedent) => {
                //如果下面这行代码用InnerExceptions属性获取异常信息,first()就是获取到的第一个异常
                //如果下面这行代码用InnerException属性获取异常信息,获取最后一个异常
               if (antecedent.Status==TaskStatus.RanToCompletion) //RanToCompletion表示任务成功完成了
                {
                    Console.WriteLine($"Result from Count-up:{antecedent.Result.Sum}");
                   
                } else if (antecedent.Status == TaskStatus.Faulted) //Faulted表示任务执行过程中发生了异常
                {
                    Console.WriteLine($"Exception occurred {task1.Exception.InnerExceptions.First().Message}");
                }
                else
                {
                    //其他状态的处理
                    //WaitingForActivation表示任务对象生成了，正在等待被激活，
                    //WaitingToRun表示任务正在等待被调度器调度
                    //Running表示任务正在运行，
                    //Canceled表示任务被取消了
                    //这里我们就简单的输出一下状态
                }



            });


            //下例是链式调用，前一个任务完成后，才会执行后一个任务

            Task.Factory.StartNew(() => {
                return downCount.CountDown(20);
            }).ContinueWith((antecedent) =>
            {
                Console.WriteLine($"Result from Count-down:{antecedent.Result.Sum}");
            });


            //等待task1或task2完成,已完成就调用当前的线程继续执行
            /* int firstid = Task.WaitAny(task1, task2);
             if (firstid == 0)
             {
                 Console.WriteLine($"Result from Count-up:{task2.Result.Sum}");
             }
             else
             {
                 Console.WriteLine($"Result from Count-down:{task2.Result.Sum}");
             }*/
            Console.WriteLine("main thread over"); //主线程没有阻塞，这样的好处就是 主线程可以继续执行其他的任务，不会被阻塞在等待上，提升了程序的效率和响应性

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
                //Task.Delay(1300).Wait();
            }
            Console.WriteLine("\nCount-up end");
            //抛出异常会被赋值给aggregateException的innerException属性
            throw new Exception("exception is start");
            
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
