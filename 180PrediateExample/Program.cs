// See https://aka.ms/new-console-template for more information
using _180PrediateExample;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
Publisher pub = new Publisher();
pub.MyEvent += (a)=> a>0;


bool result=pub.RaiseEvent(10);
Console.WriteLine(pub.RaiseEvent(-10));