namespace _231IComparableExample
{
    public class Employee : IComparable
    {
        public int EmpID { get; set; }
        public String EmpName { get; set; }
        public string Job { get; set; }

        public int Salary { get; set; }
        public int CompareTo(object? obj)
        {
            Console.WriteLine(this.EmpID+","+((Employee)obj).EmpID);
            return 0;
        }
    }

   



    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees= new List<Employee>() {
            
                new Employee() { EmpID=1, EmpName="张三", Job="程序员", Salary=10000 },

                new Employee() { EmpID=2, EmpName="李四", Job="程序员", Salary=12000 },

                new Employee() { EmpID=3, EmpName="王五", Job="程序员", Salary=8000 },
            
            }; 
            employees.Sort();
            foreach (Employee item in employees)
            {
                Console.WriteLine(item.EmpID);
            }

        }
    }
}
