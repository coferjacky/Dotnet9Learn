using System;

namespace _201DeepCopyExample
{
    public class Student : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        

        public object Clone()
        {
            Student stu=new Student() {
                Id = this.Id,
                Name = this.Name,
                Age = this.Age
            };
          
            return stu;
        }

        public override string ToString()
        {
            return $"Student(Id: {Id}, Name: {Name}, Age: {Age})";
        }
    }
}
