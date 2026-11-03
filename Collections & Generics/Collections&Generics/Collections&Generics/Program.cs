

namespace CollectionsAndGenerics 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Data<int> d = new Data<int>();
            //Data<string> s = new Data<string>();
            //Console.WriteLine(d.GetData(10));
            //Console.WriteLine(s.GetData("Hello World!"));
            //d.Display<int>(100);
            //d.Display<string>("Hello Shoubham");
            //d.Display<double>(10.5);
            //d.GetFunc();


            // Non-Generic Class
            Collections c = new Collections();
            //c.ArrayListExample();
            //c.Hashtable();
            //c.Stack();
            //c.Queue();
            c.SortedList();

            Console.ReadLine();
        }
    }
}