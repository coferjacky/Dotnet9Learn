using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _114Interface
{
    internal interface IEmployee
    {
        string GetHealthInsuranceAmount();
        int EmpID {  get; set; }
        string EmpName { get; set; }
        string Location {  get; set; }
    }
}
