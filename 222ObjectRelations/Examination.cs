using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222ObjectRelations
{

    /// <summary>
    /// 考试类，一个学生参加多次考试
    /// </summary>
    internal class Examination
    {

        public string ExaminationName {  get; set; }
        public int Month {  get; set; } 
        public int Year {  get; set; }
        public int MaxMarks { get; set; }

        public int SecuredMarks {  get; set; }


    }
}
