using _201DeepCopyExample;

// 使用数组初始化器和对象初始化器创建10个Student实例
Student[] students =
{
    new Student { Id = 1, Name = "张三", Age = 18 },
    new Student { Id = 2, Name = "李四", Age = 19 },
    new Student { Id = 3, Name = "王五", Age = 20 },
    new Student { Id = 4, Name = "赵六", Age = 21 },
    new Student { Id = 5, Name = "钱七", Age = 18 },
    new Student { Id = 6, Name = "孙八", Age = 19 },
    new Student { Id = 7, Name = "周九", Age = 20 },
    new Student { Id = 8, Name = "吴十", Age = 21 },
    new Student { Id = 9, Name = "郑十一", Age = 18 },
    new Student { Id = 10, Name = "王十二", Age = 19 }
};
//students[2].Name = "co2";
// 输出所有学生信息
Console.WriteLine("=== 学生列表 ===");
foreach (var student in students)
{
    Console.WriteLine(student);
}
Console.WriteLine("=== 深拷贝新学生列表 ===");
//开始深拷贝
Student[] newStu=new Student[students.Length];

for (int i = 0; i < students.Length; i++)
{
   newStu[i] =(Student) students[i].Clone();
}




foreach (var student in newStu)
{
    Console.WriteLine(student);
}

students[2].Name = "co2";
Console.WriteLine("=== 深拷贝学生列表(修改了第二个元素) ===");
foreach (var student in students)
{
    Console.WriteLine(student);
}


Console.WriteLine("=== 深拷贝新学生列表(修改了第二个元素) ===");
foreach (var student in newStu)
{
    Console.WriteLine(student);
}