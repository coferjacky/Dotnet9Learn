using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _181EventHandleExample
{
    //第一步 定义事件参数类，继承自EventArgs
    public class CustomEventArgs : EventArgs
    {
        public int a { get; set; }
        public int b { get; set; }


    }

    internal class Publisher
    {
        //第二步 定义事件，使用EventHandler<T> 泛型委托类型
        public event EventHandler<CustomEventArgs> myEvent;

        //第三步 定义触发事件的方法，在类的内部调用该方法以触发事件，传递事件数据，并传递事件的发送者
        //拥有额外属性，这些属性可以作参数，再触发事件时提供值
        public void RaiseEvent(object sender,int x, int y)
        {
            if (this.myEvent != null)
            {
                CustomEventArgs customEventArgs = new CustomEventArgs() { a = x, b = y };

                //EventHandler<T> 委托类型有两个参数，第一个是事件的发送者，第二个是事件数据，订阅是用来接收值
                this.myEvent(sender, customEventArgs);
               
            }
        }


    }
}
