namespace _234CovarianceExample
{
    class PrintCharater
    {
        public void printAll(IEnumerable<Object> s) {

            foreach (var item in s)
            {
                Console.Write(item+" ");
            }


        }
    }
    class LivingThing
    {
       public  int NumberOfLeg { get; set; }
    }

    class Parrot : LivingThing
    { 
        
    }
    class Dog : LivingThing
    {

    }


    //将这个名为T的泛型参数用作方法或属性的返回类型
    interface IMover<out T>
    {       
        T Move();
    }
    class Mover<T> : IMover<T>
    {

        public T thing { get; set; }
        public T Move()
        {
            return thing;
        }
    } 

    public class Program
    {
        static void Main(string[] args)
        {
            //LivingThing livingThing = new Parrot();
            Parrot parrot = new Parrot()
            {
                NumberOfLeg = 2
            };

            IMover<LivingThing> mover = new Mover<Parrot>()
            {
                thing = parrot
            };
            Console.WriteLine(mover.Move().NumberOfLeg);

            PrintCharater pr=new PrintCharater();

            List<string> listStr = new List<string>() { "cofer","jack"};
            List<int> intNum= new List<int>() { 4,5,6,10};
            pr.printAll(listStr);
            //pr.printAll(intNum); 协变只支持引用类型，值类型不支持。
        }
    }
}
