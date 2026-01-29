using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _182ExpressionTreeExample
{
    internal class Student
    {
        private string _studentName;

        //方法可以直接写成表达式，但是方法仅只有一个表达式，可以简化
        public int GetStudentNameLength()=>_studentName.Length;
        //构造函数可以直接写成表达式，但是构造函数仅只有一个表达式，可以简化
        public Student() => _studentName = "co2";

        //属性可以直接写成表达式，但是属性仅只有一个表达式，可以简化
        
        public string StudentName
        {
            set => _studentName = value;
            get => _studentName;
        }

    }
}
