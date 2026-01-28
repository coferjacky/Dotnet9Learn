// See https://aka.ms/new-console-template for more information

using _174AutoImplementedEvents;

Console.WriteLine("Hello, World!1");
//自动实现事件的目标是 简化事件声明的语法，从而减少样板代码。

//创建发布者对象
Publisher pub = new Publisher();
//创建订阅者对象   
SubScriber sub = new SubScriber();

//订阅
pub.MyEvent += sub.Add;
pub.MyEvent += sub.Multi;

//触发事件,使得两个方法执行
pub.RaiseEvent(10, 20);