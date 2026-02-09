// See https://aka.ms/new-console-template for more informationY
using _221CollectionOfObject;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");


List<Product> products = new List<Product>();

string choice;
do
{
    Console.Write("enter prodoct id:");
    int pid=int.Parse(Console.ReadLine());

    Console.WriteLine("enter product name:");
    string pname=Console.ReadLine();

    Console.WriteLine("enter price");
    double unitPrice = double.Parse( Console.ReadLine());

    Console.WriteLine("enter date of manufacture:");
    DateTime dom = DateTime.Parse(Console.ReadLine());

    Product product = new Product() {ProductId=pid,ProductName=pname,Price=unitPrice, DateOfManufacture=dom };

    //添加到集合中
    products.Add(product);

    //问用户是否结束
    Console.WriteLine("Do you want to continue to next Product?(y/n)");

    choice =Console.ReadLine();




}while (choice!="No"&&choice!="no"&&choice!="n" && choice !="N");


foreach(Product item in products)
{
    Console.WriteLine(item.ProductName);
}