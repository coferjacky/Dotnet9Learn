// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");

Dictionary<int,string> empleyees = new Dictionary<int, string>(){

    {101,"Scott"},{ 102,"jack"},{ 103,"allen"}
};   

foreach(KeyValuePair<int,string> item in empleyees)
{
    Console.WriteLine(item.Key+","+item.Value);
   
}
//获取101的值
string s = empleyees[101];
Console.WriteLine("\nValue at 101:"+s);
//获取所有键
Dictionary<int,string>.KeyCollection  keys = empleyees.Keys;
Console.WriteLine("\nKeys:");
foreach(int itme in keys)
{
    Console.WriteLine(itme);
}

//移除某个键值对
empleyees.Remove(101);

//搜索某键
if(empleyees.ContainsKey(101))
{
    Console.WriteLine("\n101 is in the dictionary");
}
else
{
    Console.WriteLine("\n101 is not in the dictionary");
}

//搜索某值
if(empleyees.ContainsValue("Scott"))
{
    Console.WriteLine("\nScott is in the dictionary");
}
else
{
    Console.WriteLine("\nScott is not in the dictionary");
}


//清理所有元素
empleyees.Clear();



//获取所有值
Dictionary<int,string>.ValueCollection  values = empleyees.Values;
Console.WriteLine("\nValues:");
foreach(string itme in values)
{
    Console.WriteLine(itme);
}

Console.ReadKey();