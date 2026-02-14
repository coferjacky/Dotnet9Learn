// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Hello, World!");

CustomersList customersList = new CustomersList() {

                new Customer() { CustomerID = "a1", CustomerName = "张三", Email = "<EMAIL>", TypeOfCustomer = TypeOfCustomer.RegularCustomer },
                new Customer() { CustomerID = "a2", CustomerName = "李四", Email = "<EMAIL>", TypeOfCustomer = TypeOfCustomer.VIPCustomer },
                new Customer() { CustomerID = "a3", CustomerName = "王五", Email = "<EMAIL>", TypeOfCustomer = TypeOfCustomer.RegularCustomer }

};

Customer new_cust = new Customer() { CustomerID = "a1", CustomerName = "LI", Email = "D@DFA.COM", TypeOfCustomer = TypeOfCustomer.RegularCustomer };
Customer other_cust = new Customer() { CustomerID = "a1", CustomerName = "LI", Email = "D@DFA1.COM", TypeOfCustomer = TypeOfCustomer.VIPCustomer };
customersList.Add(new_cust);
Console.WriteLine(customersList.Contains(other_cust));


public class Customer:IEquatable<Customer>
{
    public string CustomerID { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; set; }

    public TypeOfCustomer TypeOfCustomer { get; set; }

    public bool Equals(Customer? other)
    {
       return this.CustomerID==other.CustomerID && this.CustomerName==other.CustomerName;
    }
}

public enum TypeOfCustomer
{
    RegularCustomer, VIPCustomer
}
public class CustomersList : IList<Customer>
{
    private List<Customer> customers = new List<Customer>();

    public int Count => customers.Count;
    //true说明集合只读
    public bool IsReadOnly => true;

    public IEnumerator<Customer> GetEnumerator()
    {
        for (int i = 0; i < customers.Count; i++)
        {
            yield return customers[i];
        }
    }


    //索引器生成
    public Customer this[int index]
    {
        get => customers[index];
        set => customers[index] = value;
    }



    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Add(Customer cust)
    {
        if (cust.CustomerID.StartsWith("A") || cust.CustomerID.StartsWith("a"))
        {
            customers.Add(cust);
        }
        else
        {
            Console.WriteLine("Invail custmer id");
        }
    }

    public int IndexOf(Customer item)
    {
        return customers.IndexOf(item);
    }

    public void Insert(int index, Customer item)
    {
        if (index < 0)
        {
            Console.WriteLine("Invail custmer id");
        }
        else
        {
            customers.Insert(index, item);
        }

    }

    public void RemoveAt(int index)
    {
        if (index < 0)
        {
            Console.WriteLine("invalid index");
        }
        else
        {
            customers.RemoveAt(index);
        }
    }

    public void Clear()
    {
        customers.Clear();
    }

    public bool Contains(Customer item)
    {
        //如果Customer实现IEquatable,则可以自己实现Equal方法中匹配对应属性 视为相同对象，否则就用内置的Contains
        //这一切都是系统自动完成
        return customers.Contains(item);
    }

    public void CopyTo(Customer[] array, int arrayIndex)
    {
        customers.CopyTo(array, arrayIndex);
    }

    public bool Remove(Customer item)
    {
        return customers.Remove(item);
    }

    public Customer Find(Predicate<Customer> match)
    {
        return customers.Find(match);
    }

    public List<Customer> FindAll(Predicate<Customer> match)
    {
        return customers.FindAll(match);
    }
}