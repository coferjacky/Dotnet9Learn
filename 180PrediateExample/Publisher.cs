using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _180PrediateExample
{
    internal class Publisher
    {
         public event Predicate<int> MyEvent;
        public bool RaiseEvent(int a)
        {
            if (MyEvent != null)
            {
                bool result = this.MyEvent(a);
                
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
