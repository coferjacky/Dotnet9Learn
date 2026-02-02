// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");
//设置10个元素的数组是有必要的，能避免频繁的扩容
List<int> list = new List<int>(10) { 12,12,12,13,16};
foreach (var item in list)
{
    Console.WriteLine(item);
}

list.Add(10); //末尾加一个元素
List<int> otherlist=new List<int>(10) { 22,23,34};
list.AddRange(otherlist); //末尾加一个集合

Console.WriteLine("new list");
foreach (var item in list)
{
    Console.WriteLine(item);
}

Console.WriteLine("new list");
//插入元素
list.Insert(1, 38);
//插入集合
List<int> otherlist1 = new List<int>(10) { 9, 8, 7 };
//插入集合位置1，集合元素个数为3
list.InsertRange(1, otherlist1);
foreach (var item in list)
{
    Console.WriteLine(item);
}

//移除元素值是2的元素
Console.WriteLine(list.Remove(12));  //只移除第一个匹配元素

Console.WriteLine(list.RemoveAll(x => x == 12)); //移除所有值是12的元素
Console.WriteLine("new list");
foreach (var item in list)
{
    Console.WriteLine(item);
}

//移除指定位置的元素
list.RemoveAt(1);

//移除从指定位置开始的2个元素
list.RemoveRange(1, 2);

//移除所有大于10的元素

Console.WriteLine("删除元素数量",list.RemoveAll(n => n > 10));
Console.WriteLine("移除所有大于10的元素,lambda表达式为真就会被执行（移除）");
foreach (var item in list)
{
    Console.WriteLine(item);
}

Console.WriteLine("清空");
list.Clear();
Console.ReadLine();


//升序
list.AddRange(10, 2, 8, 1);
list.Sort();
//降序
list.Reverse();

//找到给定值返回值的索引值，找不到返回-1 线性搜索
//如果有多个值则只找第一个值

int n=list.IndexOf(10);
//如果想找第二次出现的该值的索引
int n2=list.IndexOf(10,n+1);

//如果数据量比较大时
//二分查找集合有个前提条件，就是预先排序,而且是升序
list.BinarySearch(19);

//只关心给定值是否存在
list.Contains(10);


