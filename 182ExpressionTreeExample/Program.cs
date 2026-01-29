// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;

Console.WriteLine("Hello, World!");

Student s=new Student() { Id=11,Age=18,Name="co2"};


Expression<Func<Student,bool>> e=s=>s.Age<20 && s.Age>12;
Func<Student,bool> mydelegates=e.Compile();


//
Console.WriteLine(mydelegates.Invoke(s));


class Student
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }

}