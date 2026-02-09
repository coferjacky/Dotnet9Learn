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

        public Branch Branch { get; set; }

        public List<Examination> Examination { get; set; }

        public Grade Grade { get; set; }


    }
}
