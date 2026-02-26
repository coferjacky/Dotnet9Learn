using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _424SemaphoreDemo
{
    public class Shared
    {
        public static object LockObject {  get; set; }  
        public static string FilePath {  get; set; }
        public static int ChunkSize { get; set; }   

        public static int MaxConcurrency { get; set; }
        static Shared()
        {
            LockObject = new object();
            FilePath = "data.csv";
            ChunkSize = 100;
        }
    }
}
