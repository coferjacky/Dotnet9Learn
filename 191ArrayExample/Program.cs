// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] ArrayList = new string[10]
{
    "lishan",
    "zhangsan",
    "lisi",
    "wangwu",
    "zhaoliu",
    "zhaoliu",
     "zhaoliu",
      "zhaoliu",
     "zhaoliu",
     "zhaoliu"
};
//第一个参数是数组，第二个参数是要查找的元素，第三个参数是从哪个位置开始查找，默认是从0开始
Console.WriteLine(Array.IndexOf(ArrayList, "zhaoliu",8));



int[] ArrayListB = new int[10]
{
      0,1,2,3,4,5,6,7,8,9
};
//第一个参数是数组，第二个参数是要查找的元素
Console.WriteLine(Array.BinarySearch(ArrayListB, 9));