// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



int operation=10;
string result;

result=operation switch
{
    1=>"customer",
    2=>"employee",
    3=>"admin",
    _=>"unknown"
};
Console.WriteLine(result);