namespace _462ListPatternExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] strs = { 1,7 };
            Console.WriteLine("Hello, World!");

            //假设有个规则 ：如果数组的第一个元素是1，最后一个元素是7，并且数组长度大于3，那么就满足条件
            //下面是老方法
            if (strs.Length > 3 && strs[0] == 1 && strs[strs.Length - 1] == 7)
            {
                Console.WriteLine("满足条件");

            }

            //下面是C#11的新方法，使用列表模式
            bool b2=strs is [1,7]; //第一个元素是1，最后一个元素是7，并且数组长度大于2
            Console.WriteLine(b2);
        }
    }
}
