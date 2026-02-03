// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

List<int> list = new List<int>();
Random random = new Random();

// 增加10个随机数字
for (int i = 0; i < 10; i++)
{
    list.Add(random.Next(1, 100)); // 生成1-99之间的随机数
}

// 输出所有成员
Console.WriteLine("List 中的成员（随机数字）：");


//查看这些数字是不是存在小于20的数字
bool isExists = list.Exists(n => n < 20);
//如果有多个小于20的数字，只会返回一次TRUE
Console.WriteLine("是否存在小于20的数字：" + isExists);

//查找第一个小于20的数字(找到符合条件的第一个给定元素，如果没有)
//就返回0
var findValue=list.Find(n => n < 20);
Console.WriteLine("找到的第一个小于20的数字：" + findValue);
//查找第一个小于20的数字的索引
var findIndex=list.FindIndex(n => n < 20);
Console.WriteLine("找到的第一个小于20的数字的索引：" + findIndex);


//查找最靠后的一个小于20的数字的索引
var findLastValue =list.FindLast(n => n < 20);
Console.WriteLine("找到的最后一个小于20的数字：" + findLastValue);


//查找最靠后的一个小于20的数字的索引
var findLastIndex =list.FindLastIndex(n => n < 20);

Console.WriteLine("找到的最后一个小于20的数字的索引：" + findLastIndex);


//查找所有小于20的数字，返回一个集合

List<int> findAll =list.FindAll(n => n < 20);

findAll.ForEach(n => Console.WriteLine(n));


