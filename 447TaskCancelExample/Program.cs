using System.Net.Http.Headers;

namespace _447TaskCancelExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UpCounter upCount = new UpCounter();
            DownCounter downCount = new DownCounter();
            //创建一个CancellationTokenSource对象,它可以用来发出取消任务的请求
            CancellationTokenSource cancellationTokenSource =new CancellationTokenSource();
            //cancellationTokenSource.Token

            //第一个参数是一个委托，表示要执行的任务，第二个参数是一个CancellationToken对象，用于监听取消请求
            Task.Run(() => {
                return upCount.CountUp(20,cancellationTokenSource.Token);
            },cancellationTokenSource.Token).ContinueWith((antecedent) => {
                //如果下面这行代码用InnerExceptions属性获取异常信息,first()就是获取到的第一个异常
                //如果下面这行代码用InnerException属性获取异常信息,获取最后一个异常
                if(antecedent.Status== TaskStatus.Canceled)
                {
                    Console.WriteLine("Count-up task Canceled");
                    return -1;
                }
                else if (antecedent.Status == TaskStatus.Faulted) //Faulted表示任务执行过程中发生了异常
                {
                    Console.WriteLine($"Exception occurred {antecedent.Exception.InnerExceptions.First().Message}");
                    return -1;
                }
                else if (antecedent.Status == TaskStatus.RanToCompletion) //RanToCompletion表示任务成功完成了
                {
                    return antecedent.Result;
                }
                else
                {
                    return -1;
                }                       
            }).ContinueWith(antecedent =>
            {
                if(antecedent.Result != -1)
                {
                    Console.WriteLine($"Result from count-up: {antecedent.Result}");
                }
              
            });

            //编写取消逻辑,取消该令牌引用的特定任务，在5秒后取消任务
             Task.Delay(5000).Wait();
            cancellationTokenSource.Cancel();



            //下例是链式调用，前一个任务完成后，才会执行后一个任务

            Task.Factory.StartNew(() => {
                return downCount.CountDown(20);
            }).ContinueWith((antecedent) =>
            {
                Console.WriteLine($"Result from Count-down:{antecedent.Result}");
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
        //CancellationToken 是取消令牌，用于取消任务,它是一个结构体，可以用来监听取消请求
        public long CountUp(int count,CancellationToken ct)
        {
            long sum = 0;
            Console.WriteLine("\nCount-up start");
            for (int i = 1; i < count; i++)
            {
                /* 这个方法是用来判断是否取消了任务，不推荐
                 * if (!ct.IsCancellationRequested)
                 {
                     Console.Write($"i={i}, ");
                     sum += i;
                     //我模拟一个耗时的操作，每隔几秒输出1个数字,谁调用这个方法，谁就会被阻塞
                     //现实世界项目中，可能是一个耗时的计算，或者是一个IO操作，或者是一个网络请求等，要避免
                     Task.Delay(1300).Wait();
                 }*/
                ct.ThrowIfCancellationRequested(); //throw new OperationCancellationException(),一旦抛出异常，该代码的循环就不会执行了
                Console.Write($"i={i}, ");
                sum += i;
                //我模拟一个耗时的操作，每隔几秒输出1个数字,谁调用这个方法，谁就会被阻塞
                //现实世界项目中，可能是一个耗时的计算，或者是一个IO操作，或者是一个网络请求等，要避免
                Task.Delay(1300).Wait();
            }
            Console.WriteLine("\nCount-up end");
            //抛出异常会被赋值给aggregateException的innerException属性
            //throw new Exception("exception is start");

            return sum;


        }
    }

    class DownCounter
    {
        public long CountDown(int count)
        {
            long sum = 0;
            Console.WriteLine("\nCount-down start");
            for (int i = count; i >= 1; i--)
            {
                Console.Write($"j={i}, ");
                sum += i;
            }
            Console.WriteLine("\nCount-down end");
            return sum;

        }
    }

    //设置一个类
    class SumData
    {
        public long Sum { get; set; }
    }
}
