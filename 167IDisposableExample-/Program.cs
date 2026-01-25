// See https://aka.ms/new-console-template for more information
using _167IDisposableExample;

Console.WriteLine("Hello, World!");

using(Sample sample = new Sample())
{
    sample.DisplayDate();
}