// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

// 创建 List<int> 并添加一些数字
List<int> intList = new List<int> { 1, 2, 3, 4, 5 };

Console.WriteLine("原始 List<int>:");
foreach (int num in intList)
{
    Console.Write(num + " ");
}
Console.WriteLine();

// 使用 ConvertAll 将 List<int> 转换为 List<string>
List<string> stringList = intList.ConvertAll(x => x.ToString());

Console.WriteLine("转换后的 List<string>:");
foreach (string str in stringList)
{
    Console.Write(str + " ");
}
Console.WriteLine();

// 使用 ConvertAll 将数字平方，转换为新的 List<int>
List<int> squaredList = intList.ConvertAll(x => x * x);

Console.WriteLine("平方后的 List<int>:");
foreach (int num in squaredList)
{
    Console.Write(num + " ");
}
Console.WriteLine();
