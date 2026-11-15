using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionPractices
{
    class Collections
    {
        public void Example1()
        {
            int[] numbers = { 1, 2, 3, 4, 2, 5, 6 };
            int target = 7;
            HashSet<string> pair = new HashSet<string>();
            for(int i = 0; i < numbers.Length; i++)
            {
                for(int j = i+1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                    {
                        pair.Add($"[{numbers[i]},{numbers[j]}]");
                    }
                }
            }
            foreach (var item in pair)
            {
                Console.WriteLine(item);
            }
        }

        public void Example2()
        {
            string text = "programming";

            Dictionary<char, int> freq = new Dictionary<char, int>();
            foreach (var i in text)
            {
                if (freq.ContainsKey(i))
                {
                    freq[i]++;
                }
                else 
                {
                    freq[i] = 1;
                }
            }
            foreach(var item in freq)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
}
