namespace _233IComparer
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Job { get; set; }
    }

    public enum SortBy
    {
        EmpID,

        EmpName,

        Job
    }

    class CustomerComparer : IComparer<Employee>
    {
       /* public int Compare(Employee? x, Employee? y)
        {
            int jobComparison = 0;
            //1.只按照EmpID排序
            //jobComparison = x.EmpID - y.EmpID;
            
            //2.只按照EmpName排序
            //jobComparison= x.EmpName.CompareTo(y.EmpName);

            //3.先按照Job排序，Job相同按照EmpID排序
            if(x.Job != null)
            {
                jobComparison= x.Job.CompareTo(y.Job);
            }
            if (jobComparison == 0)
            {
                if(x.EmpName != null)
                {
                    jobComparison = x.EmpName.CompareTo(y.EmpName);
                }
                
            }
            

            
            return jobComparison;
        }*/


        public SortBy SortBy { get; set; }

        public int Compare(Employee? x, Employee? y)
        {
            int jobComparison = 0;
            switch (this.SortBy)
            {
                case SortBy.EmpID:
                    jobComparison = x.EmpID - y.EmpID;
                    break;
                case SortBy.EmpName:
                    jobComparison = (x.EmpName!=null)?x.EmpName.CompareTo(y.EmpName):0;
                    break;
                case SortBy.Job:
                    jobComparison = (x.Job!=null)?x.Job.CompareTo(y.Job):0;
                    break;
                default:
                    jobComparison = 0;
                    break;
            }       

            return jobComparison;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>() { 
            
                new Employee(){EmpID=104,EmpName="Mary",Job="Designer"},
                new Employee(){EmpID=101,EmpName="Tom",Job="Developer"},
                new Employee(){EmpID=102,EmpName="Jerry",Job="Consultant"},
                new Employee(){EmpID=103,EmpName="Jack",Job="Developer"},
                new Employee(){EmpID=100,EmpName="Tom",Job="Manager"},
                new Employee(){EmpID=108,EmpName="rofer",Job=null}
            
            };
            CustomerComparer customerComparer = new CustomerComparer();
            customerComparer.SortBy = SortBy.Job;
            
            
            list.Sort(customerComparer);
            foreach (var item in list)
            {
                Console.WriteLine(item.EmpID+","+item.EmpName+","+item.Job);
            }
        }
    }
}
