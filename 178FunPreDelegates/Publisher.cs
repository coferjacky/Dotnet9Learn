using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _178FunPreDelegates
{
    //最后连自定义委托都懒得写了
    internal class Publisher
    {
        //Func有16个参数，前面15是参数类型，最后一个是值类型，如果是只有一个参数，则是一个返回类型
        public event Func<int, int, int> MyEvent;

        public int RaiseEevent(int a,int b)
        {
            if (MyEvent != null) { 
                return this.MyEvent(a, b);
            }
            else
            {
                return 0;
            }
            
        }
    }
}
