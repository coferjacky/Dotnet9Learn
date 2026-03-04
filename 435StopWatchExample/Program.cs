
using System.Diagnostics;
using System.Diagnostics.Metrics;


Stopwatch sw=new Stopwatch();


//Tasks
sw.Start();
WithTasks();
sw.Stop();

long timeTakenForTasks=sw.ElapsedMilliseconds;

Console.WriteLine($"\nTasks - Time Taken {timeTakenForTasks} ms");


//Threads

sw.Restart();
WithThreads();
sw.Stop();

long timeTakenForThreads = sw.ElapsedMilliseconds;

Console.WriteLine($"\nThreads - Time Taken {timeTakenForThreads} ms");

Console.ReadKey();

static void WithTasks()
{
    UpCounter upCount = new UpCounter();
    DownCounter downCount = new DownCounter();

    //初始计数指定为
    CountdownEvent countdownEvent = new CountdownEvent(2);


    //下面不要这样创建Task对象
    //Task task = new Task();
    Task task1 = Task.Run(() =>
    {
        upCount.CountUp(20);
        //初始计数减1
        countdownEvent.Signal();
    });

    Task task2 = Task.Run(() =>
    {
        downCount.CountDown(20);
        //任务结束后计数器减1
        countdownEvent.Signal();
    });

    //等待两个任务完成 才开始往后执行
    countdownEvent.Wait();
  

}

static void WithThreads()
{
    UpCounter upCount = new UpCounter();
    DownCounter downCount = new DownCounter();

    //初始计数指定为
    CountdownEvent countdownEvent = new CountdownEvent(2);


    //下面不要这样创建Task对象
    //Task task = new Task();
    Thread thread1 = new Thread(() =>
    {
        upCount.CountUp(20);
        //初始计数减1
        countdownEvent.Signal();
    });

    Thread thread2 = new Thread(() =>
    {
        downCount.CountDown(20);
        //任务结束后计数器减1
        countdownEvent.Signal();
    });

    thread1.Start();
    thread2.Start();

    //等待两个任务完成 才开始往后执行
    countdownEvent.Wait();
   

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
