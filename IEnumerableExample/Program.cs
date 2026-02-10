// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


IEnumerable<string> list = new List<string>() { "how are you","how old you "};
foreach (var item in list)
{
    Console.WriteLine(item);
}
//模拟IEnumerator如何实现
Console.WriteLine("模拟IEnumerator如何实现");
IEnumerator<string> et = list.GetEnumerator(); 
//将指针reset
et.Reset();
et.MoveNext();
Console.WriteLine(et.Current);

