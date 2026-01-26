// See https://aka.ms/new-console-template for more information
using _168UsingDeclaration;

Console.WriteLine("Hello, World!");

DoWork();
static void DoWork()
{
    using Sample s = new Sample();
    s.DisplayDate();
}
