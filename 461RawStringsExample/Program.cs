using System.Security.Cryptography.X509Certificates;

namespace _461RawStringsExample
{
    /*
     {
         "name": "Alice",
         "age": 30
     }
     * 
     * 
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            //原来是这么表示
            string str1 = "{\r\n         \"name\": \"Alice\",\r\n         \"age\": 30\r\n     }";
            //C#11以后可以这么表示
            string str = """
            {
                "name": "Alice",
                "age": 30
            }
            """;
            string name = "aaa";
            int age = 12;
            string messgage = $"""
                hello,{name},
                your age "" is {age}
                """;



            Console.ReadKey();
        }
    }
}
