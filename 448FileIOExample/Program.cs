namespace _448FileIOExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName=@"test.txt";
            FileWriter fileWriter = new FileWriter();
            FileReader fileReader = new FileReader();

            Task writerTask= fileWriter.WriteFile(fileName,"China is big");
            
            writerTask.Wait(); //等待写入操作完成
           
            Console.WriteLine("File written");

            Task<string> readerTask=fileReader.ReadFile(fileName);
            writerTask.Wait(); //等待读取操作完成
            Console.WriteLine("File read");
            Console.WriteLine($"\nFIle content:{readerTask.Result}");

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
