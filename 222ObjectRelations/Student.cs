using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222ObjectRelations
{
    internal class Student
    {
        public int RollNo {  get; set; }
        public string StudentName {  get; set; }

        public string Email {  get; set; }

        //1对1关系
        public Branch branch { get; set; }

        //1对多关系
        public List<Examination> examinations { get; set; }

        public Grade grade { get; set; }


    }
}
