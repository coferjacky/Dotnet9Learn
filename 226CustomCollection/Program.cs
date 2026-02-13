// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Hello, World!");

//可以自动调用Add方法
CustomersList customersList = new CustomersList() {

       new Customer() { CustomerID = "a1", CustomerName = "张三", Email = "<EMAIL>", TypeOfCustomer = TypeOfCustomer.RegularCustomer },
        new Customer() { CustomerID = "a2", CustomerName = "李四", Email = "<EMAIL>", TypeOfCustomer = TypeOfCustomer.VIPCustomer },
        new Customer() { CustomerID = "a3", CustomerName = "王五", Email = "<EMAIL>", TypeOfCustomer = TypeOfCustomer.RegularCustomer }

};


Customer new_customer = new Customer() { CustomerID="11",CustomerName="jack",Email="fdd@da.com",TypeOfCustomer=TypeOfCustomer.VIPCustomer};

customersList.Add(new_customer);

//IEnumerator enumerator=customersList.GetEnumerator();
/*enumerator.MoveNext();
Console.WriteLine(enumerator.Current);

enumerator.MoveNext();
Console.WriteLine(enumerator.Current);

enumerator.MoveNext();
Console.WriteLine(enumerator.Current);*/

foreach (Customer item in customersList)
{
    Console.WriteLine(item.CustomerID);
}



public enum TypeOfCustomer
{
    RegularCustomer,VIPCustomer
}

public class Customer
{
    public string CustomerID {  get; set; }
    public string CustomerName { get; set; }
    
    public string Email { get; set; }

    public TypeOfCustomer TypeOfCustomer { get; set; }  



}

public class CustomersList:IEnumerable
{
    //这个已经私有了
    private List<Customer> customers = new List<Customer>();  
    
     
    
    
    public List<Customer> GetCustomers()
    {
        return customers;
    }

    public IEnumerator GetEnumerator()
    {
        for(int i=0;i<customers.Count;i++)
        {
            yield return customers[i];
        }    
        /* yield return customers[1];
        yield return customers[2];*/
    }

    public void Add(Customer cust)
    {
        if (cust.CustomerID.StartsWith("A")||cust.CustomerID.StartsWith("a"))
        {
           customers.Add(cust);
        }
        else
        {
            Console.WriteLine("Invail custmer id");
        }
    }


}