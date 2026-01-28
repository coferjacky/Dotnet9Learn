// See https://aka.ms/new-console-template for more information


using _179ActionPredicate;

Console.WriteLine("Hello, World!");

Publisher pub = new Publisher();
pub.MyEvent += (a, b) =>
{

    Console.WriteLine(a + b);

};
pub.RaiseEevent(11,45);
