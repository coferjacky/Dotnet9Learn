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

/*Branch br=new Branch();
br.BranchName = "Computer Science Engineering";
br.NoOfSemesters = 8;
student.Branch= br;*/
//1对1
student.branch=new Branch();
student.branch.BranchName = "english";
student.branch.NoOfSemesters = 13;
Console.WriteLine(student.branch.BranchName + " " + student.branch.NoOfSemesters);


//1对多关系
student.examinations=new List<Examination>();
//添加三个科目及分数
student.examinations.Add(new Examination() { ExaminationName="Math",MaxMarks=100,Month=12,Year=2000,SecuredMarks=89});

student.examinations.Add(new Examination() { ExaminationName = "Chinese", MaxMarks = 100, Month = 3, Year = 2001, SecuredMarks = 89 });

student.examinations.Add(new Examination() { ExaminationName = "Chinese-2", MaxMarks = 100, Month = 3, Year = 2004, SecuredMarks = 67});

Console.WriteLine(student.RollNo);
Console.WriteLine(student.StudentName);
Console.WriteLine(student.Email);
Console.WriteLine(student.branch.BranchName + " " +student.branch.NoOfSemesters );
Console.WriteLine("-------学生考试课程明细（one to many）---------");
foreach (Examination item in student.examinations)
{
    Console.WriteLine(item.ExaminationName + " / " + item.MaxMarks + " / " + item.Year + " / " + item.Month + " / " + item.SecuredMarks);
}


//多对一
Grade grade = new Grade() { GradeId=1,GradeName="grade11" };
student.grade = grade;
student2.grade = grade;

Console.WriteLine("第一个学生");
Console.WriteLine("学生ID:"+student.RollNo+"，学生姓名:"+student.StudentName+",学生年级ID："+student.grade.GradeId+ ",学生年级名称：" + student.grade.GradeName);



