using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _173EventExample
{
    //第一步 定义委托类型
    public delegate void MyDelegateType(int a, int b);
    //发布者
    internal class Publisher
    {
        //第二步 定义私有委托类型变量，用于保存被调用方法的引用
        //只要有人订阅了事件，就会把方法保存到这个变量中（多播委托）
        private MyDelegateType myDelegate;
        
        
        //step 1 创建事件
        public event MyDelegateType MyEvent
        {
            add //方法在添加事件处理方法时调用
            {
                myDelegate += value; 
            }
            remove //方法在移除事件处理方法时调用
            {
                myDelegate -= value;
            }
            
        }

        public void RaiseEvent(int a, int b)
        {
            //step 2 同一类中，调用事件（不能在其他类中触发事件）
            if (myDelegate != null)
            {
                this.myDelegate(10, 39);
            }
        }
    }
}
