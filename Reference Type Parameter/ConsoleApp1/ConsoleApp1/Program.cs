

namespace ReferenceTypeParameter
{
    class Program
    {


        public static void Main(string[] args)
        {
            RefTypeParameter p = new RefTypeParameter();

            int x = 10;
            int y = 12;
            Console.WriteLine($"Before swapping Display: x = {x}, y = {y}");
            p.Display(ref x, ref y);

            Console.WriteLine("Out Parameter: ");
            p.Show(x, y, out int a, out int b);

            Console.WriteLine("in Parameter: ");
            p.ShowInPara(in x);

            Console.ReadLine();
        }
    }
}