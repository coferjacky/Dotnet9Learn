using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420ThreadCsvExample
{
    internal class DataProcessor
    {
        public string ChunkName { get; set; }
        public List<string> Chunk { get; set; }

        public Dictionary<string, int> GenderCounts=new Dictionary<string, int>();
        public void ProcessChunk()
        {
            //1,Tabbitha,Warrington,twarrington0@a8.net,Female
            foreach (string line in Chunk)
            {
                if (string.IsNullOrEmpty(line)) continue;
                string[] values=line.Split(",");
                if (values.Length >= 5) {
                  string gender=  values[4].Trim().ToLower();
                  if (GenderCounts.ContainsKey(gender))
                  {
                        GenderCounts[gender]++;
                  }
                  else
                  {
                        GenderCounts.Add(gender,1);
                  }
                }
                
            }
            Thread.Sleep(100*new Random().Next(2,5));
            
        }
    }
}
