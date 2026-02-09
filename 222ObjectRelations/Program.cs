// See https://aka.ms/new-console-template for more information
using _222ObjectRelations;

Console.WriteLine("Hello, World!");


Student student = new Student();
student.RollNo = 13;
student.StudentName = "jackbual";
student.Email = "scott@gmail.com";

Student student2 = new Student();
student2.RollNo = 14;
student2.StudentName = "jackbual1";
student2.Email = "scott1@gmail.com";

//分支类对象
//Branch br = new Branch();

//br.BranchName = "computer";
//br.NoOfSemesters = 8;


//one to one relation
//student.Branch= br;

student.Branch=new Branch();
student.Branch.BranchName = "english";
student.Branch.NoOfSemesters = 13;
student.Examination=new List<Examination>();
student.Examination.Add(new Examination() { ExaminationName="Math",MaxMarks=100,Month=12,Year=2000,SecuredMarks=89});

student.Examination.Add(new Examination() { ExaminationName = "Chinese", MaxMarks = 100, Month = 3, Year = 2001, SecuredMarks = 89 });

student.Examination.Add(new Examination() { ExaminationName = "Chinese-2", MaxMarks = 100, Month = 3, Year = 2004, SecuredMarks = 67});



Console.WriteLine(student.RollNo);
Console.WriteLine(student.StudentName);
Console.WriteLine(student.Email);
Console.WriteLine(student.Branch.BranchName + " " +student.Branch.NoOfSemesters );
//多对一

Grade grade = new Grade() { GradeId=1,GradeName="grade11" };
student.Grade = grade;
student2.Grade = grade;


Console.WriteLine("-------学生考试课程明细（one to many）---------");
foreach (Examination item in student.Examination)
{
    Console.WriteLine(item.ExaminationName+" / "+item.MaxMarks+" / "+item.Year+" / "+item.Month+" / "+item.SecuredMarks);
}


