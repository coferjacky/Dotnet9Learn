using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _426ThreadPoolExample
{
    public class Shared
    {
        public static Mutex mutex {  get; set; }  
        public static string FilePath {  get; set; }
        public static int ChunkSize { get; set; }   

        public static int MaxConcurrency { get; set; }


        static Shared()
        {
            mutex = new Mutex();
            FilePath = "data.csv";
            ChunkSize = 100;
            MaxConcurrency = 3;
        }
    }
}
