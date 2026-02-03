// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
List<string> list = new List<string>();
list.Add("abc");
list.Add("efg");
list.Add("hsj");

//list.ToArray(）将list转换为数组
string[] newList=list.ToArray();
//调用foreach方法，传入lambda表达式,lambda表达式中n为list中的元素
list.ForEach(n => Console.WriteLine(n));


