namespace _452AsyncAwaitExample
{
    internal class Program
    {
        public async static Task Main(string[] args)
        {
            string fileName = @"c:\code\test.txt";
            FileWriter fileWriter = new FileWriter();
            FileReader fileReader = new FileReader();

            //写入文件内容
            Task writerTask = fileWriter.WriteFile(fileName, "China is big");

            await writerTask; //等待写入操作完成,当前主线程被阻塞，直到写入完成

            Console.WriteLine("File written");


            //读取文件内容
            Task<string> readerTask = fileReader.ReadFile(fileName);
            await readerTask; //等待读取操作完成,当前主线程被阻塞，直到读取完成
            Console.WriteLine("File read done");


            Console.WriteLine($"\nFIle content:{readerTask.Result}");
            Console.ReadKey();
        }
    }



    class FileWriter
    {
        public async Task WriteFile(string fileName, string data)
        {
            StreamWriter writer = new StreamWriter(fileName);

            //返回task对象，表示异步写入操作的状态和结果
            Task writerTask = writer.WriteAsync(data);
            await writerTask; //等待写入操作完成，当前方法被挂起，执行线程可以去执行其他任务，直到写入完成后继续执行下面的代码
            writer.Close();
            //直接返回task对象，如果你是返回值，你就会被阻塞，直到写入完成，才会返回结果
            //return writerTask; 这里会自动返回一个新的task对象，表示整个方法的执行状态和结果
        }
    }

    class FileReader
    {
        public async Task<string> ReadFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);

            //返回task对象，表示异步读取操作的状态和结果 
            Task<string> readerTask = reader.ReadToEndAsync();
          //等待读取操作完成，当前方法被挂起，执行线程可以去执行其他任务，直到读取完成后继续执行下面的代码
            string content= await readerTask; //获取读取的内容
            reader.Close();
            //return readerTask;
            return content; //这里会自动返回一个新的task对象，表示整个方法的执行状态和结果

        }
    }
}
