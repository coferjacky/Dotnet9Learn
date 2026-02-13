using System.Collections;

namespace _227CustomerCollectionTExample
{

   
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomersList customersList = new CustomersList() {

                new Customer() { CustomerID = "a1", CustomerName = "张三", Email = "<EMAIL>", TypeOfCustomer = TypeOfCustomer.RegularCustomer },
                new Customer() { CustomerID = "a2", CustomerName = "李四", Email = "<EMAIL>", TypeOfCustomer = TypeOfCustomer.VIPCustomer },
                new Customer() { CustomerID = "s3", CustomerName = "王五", Email = "<EMAIL>", TypeOfCustomer = TypeOfCustomer.RegularCustomer }

            };

            foreach (Customer item in customersList)
            {
                Console.WriteLine(item.CustomerID);
            }
        }
    }

    public enum TypeOfCustomer
    {
        RegularCustomer, VIPCustomer
    }
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }

        public string Email { get; set; }

        public TypeOfCustomer TypeOfCustomer { get; set; }

    }

    public class CustomersList: IEnumerable<Customer>
    {
        private List<Customer> customers = new List<Customer>();
          

        public IEnumerator<Customer> GetEnumerator()
        {
            for (int i = 0; i < customers.Count; i++)
            {
                yield return customers[i];
            }
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
    }
}
