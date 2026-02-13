using System.Collections;

namespace _229IListExample
{


    internal class Program
    {
        static void Main(string[] args)
        {
            CustomersList customersList = new CustomersList() {

                new Customer() { CustomerID = "a1", CustomerName = "张三", Email = "<EMAIL>", TypeOfCustomer = TypeOfCustomer.RegularCustomer },
                new Customer() { CustomerID = "a2", CustomerName = "李四", Email = "<EMAIL>", TypeOfCustomer = TypeOfCustomer.VIPCustomer },
                new Customer() { CustomerID = "a3", CustomerName = "王五", Email = "<EMAIL>", TypeOfCustomer = TypeOfCustomer.RegularCustomer }

            };

            Customer new_cust = new Customer() { CustomerID = "a1", CustomerName = "LI", Email = "D@DFA.COM", TypeOfCustomer = TypeOfCustomer.RegularCustomer };
            customersList.Add(new_cust);


            //Contains
            Console.WriteLine("数量" + customersList.Count);

            //CopyTo
            Customer[] array = new Customer[customersList.Count];

            customersList.CopyTo(array, 0);


            //Find
            Customer customer = customersList.Find(cust => cust.CustomerID == "a2");
            if (customer != null)
            {
                Console.WriteLine(customer.CustomerName);
            }


            //FindAll
            List<Customer> customer1 = customersList.FindAll(cust => cust.TypeOfCustomer == TypeOfCustomer.RegularCustomer);
            Console.WriteLine("---------vip-----------");
            foreach (Customer item in customer1)
            {
                Console.WriteLine("VIP:" + item.CustomerName);
            }

            customersList.Remove(new_cust);
            //Index of 
            Console.WriteLine("indexof:"+customersList.IndexOf(new_cust));

            //insert
            customersList.Insert(3, new_cust);
            Console.WriteLine("数量" + customersList.Count);


            Console.WriteLine("---insert---[2]---");
            Console.WriteLine(customersList[3].CustomerID+" "+ customersList[3].CustomerName); 



            Console.WriteLine("---------new_cust-----------");
            Console.WriteLine("Contain:" + customersList.Contains(new_cust));
            foreach (Customer item in customersList)
            {
                Console.WriteLine(item.CustomerID);
            }


            Console.WriteLine("-------copyto-------");
            foreach (Customer item in array)
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
            set => customers[index]=value; 
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
            if(index < 0)
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
}
