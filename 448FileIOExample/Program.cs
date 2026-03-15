namespace _448FileIOExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName=@"c:\code\test.txt";
            FileWriter fileWriter = new FileWriter();
            FileReader fileReader = new FileReader();

            //写入文件内容
            Task writerTask = fileWriter.WriteFile(fileName,"China is big");
            
            writerTask.Wait(); //等待写入操作完成
           
            Console.WriteLine("File written");


            //读取文件内容
            Task<string> readerTask=fileReader.ReadFile(fileName);
            readerTask.Wait(); //等待读取操作完成,当前主线程被阻塞，直到读取完成
            Console.WriteLine("File read done");


            Console.WriteLine($"\nFIle content:{readerTask.Result}");
            Console.ReadKey();
        }
    }



    class FileWriter
    {
        public Task WriteFile(string fileName,string data)
        {
            StreamWriter writer = new StreamWriter(fileName);

            //返回task对象，表示异步写入操作的状态和结果
           Task writerTask= writer.WriteAsync(data);

            writer.Close();
            //直接返回task对象，如果你是返回值，你就会被阻塞，直到写入完成，才会返回结果
            return writerTask;
        }       
    }

    class FileReader
    {
        public Task<string> ReadFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);

            //返回task对象，表示异步读取操作的状态和结果 
            Task<string> readerTask = reader.ReadToEndAsync();

            reader.Close();
            return readerTask;

        }
    }
}
