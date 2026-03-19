namespace _456AsyncAwaitException
{ 
    internal class Program
    {
        public async static Task Main(string[] args)
        {
            string fileName = @"c:\code\test.txt";
            FileWriter fileWriter = new FileWriter();
            FileReader fileReader = new FileReader();

            //写入文件内容
            await fileWriter.WriteFile(fileName, "China is big");

            /* await writerTask; //等待写入操作完成,当前主线程被阻塞，直到写入完成*/

            Console.WriteLine("File written");

            try
            {
                //读取文件内容
                string content = await fileReader.ReadFile(fileName);
                /*await readerTask; //等待读取操作完成,当前主线程被阻塞，直到读取完成*/
                Console.WriteLine("File read done");


                Console.WriteLine($"\nFIle content:{content}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            Console.ReadKey();
        }
    }



    class FileWriter
    {
        public async Task WriteFile(string fileName, string data)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                await writer.WriteAsync(data);
            }


        }
    }

    class FileReader
    {
        public async Task<string> ReadFile(string fileName)
        {
            //这个方法不应被调用，抛出异常以模拟错误情况
            throw new NotSupportedException();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string content = await reader.ReadToEndAsync();
                return content;
            }



        }
    }
}
