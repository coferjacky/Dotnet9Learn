// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");
//设置10个元素的数组是有必要的，能避免频繁的扩容
List<int> list = new List<int>(10) { 12,12,12,13,16};
foreach (var item in list)
{
    Console.WriteLine(item);
}