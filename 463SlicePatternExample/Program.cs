namespace _463SlicePatternExample
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            Console.WriteLine(new List<int> { 10, 2, 33, 6 } is [10, < 3, 33 or 100, > 8 and < 100]); //false ,因为最后一个元素6不满足>8的条件
            //下面划线丢弃了6，所以不参与匹配
            Console.WriteLine(new List<int> { 10, 2, 33, 6 } is [10, < 3, 33 or 100,_]); //true,因为划线丢弃了6，所以不参与匹配
                                                                                         //
            Console.WriteLine(new List<int> { 10, 2, 33, 9,6 } is [10, < 3, 33 or 100, ..]); //true ,因为..表示匹配任意数量的元素，所以9和6都被..匹配了，所以不参与匹配

            //可以用嵌套模式
            Console.WriteLine(new List<int> { 10, 2, 33, 9,6,200 } is [10, < 3, 33 or 100, ..[_,6,200]]); //true,因为..匹配了9，所以最后三个元素参与匹配了，所以满足条件
            Console.WriteLine(new List<int> { 10, 2, 33, 9,6,200 } is [10, < 3, 33 or 100, ..[_,200,_]]); //false,因为..匹配了9和6，所以最后三个元素参与匹配了，但是200不满足条件，所以不满足条件
            Console.ReadKey();
        }
    }
}
