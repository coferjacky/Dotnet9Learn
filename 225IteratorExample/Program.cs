// See https://aka.ms/new-console-template for more information
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Hello, World!");


Sample s = new Sample();
var enumerable1=s.Method();
var prices_enumberator1=enumerable1.GetEnumerator();
prices_enumberator1.MoveNext(); //执行迭代器方法



Console.WriteLine("first="+ prices_enumberator1.Current); //输出90
prices_enumberator1.MoveNext();
Console.WriteLine("second"+prices_enumberator1.Current); //输出100

Console.WriteLine("Colletion my");




/*
foreach (var item in enumerable1)
{

    //效果和8-11行相同
    Console.WriteLine(item);
}
*/





public class Sample
{
    //迭代器方法
    public List<double> Prices { get; set; } = new List<double>(){90,10,30,20};
    
    public IEnumerable<double> Method()
    {
        /*Console.WriteLine("Iterator method executes");
        yield return 10;
        Console.WriteLine("iterator method executes continued");
        yield return 29;*/

        double sum = 0;

        foreach(double price in Prices)
        {
            sum += price;
            yield return sum;
        }
        //上句等效下句
        
        /*sum += Prices[0];
        yield return sum;
        sum += Prices[1];
        yield return sum;

        sum += Prices[2];
        yield return sum;

        sum += Prices[3];
        yield return sum;*/
    }
    


}


