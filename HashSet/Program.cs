using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strText = "Подсчитайте, сколько уникальных символов в этом предложении, используя HashSet<T>, учитывая знаки препинания, но не учитывая пробелы в начале и в конце предложения.";
            var hSet = new HashSet<string>();
            var hSetSpace = new HashSet<string>()
            {
                " "
            };

            //hSet.SymmetricExceptWith(new[] { "Дмитрий", "Сергей", "Игорь" });
            //Console.WriteLine("Элементы после объединения с новой коллекцией:");
            //foreach (var n in hSet)
            //    Console.WriteLine(n);
            foreach (char n in strText)
            {
                //string nstr = n.ToString();
                    //hSet.Add(nstr);
                hSet.Add(n.ToString());
                //Console.WriteLine(n); 
            }
                
            foreach (var n in hSet)    
                Console.WriteLine(n);

            Console.WriteLine(hSet.Count);
            hSet.ExceptWith(hSetSpace);
            Console.WriteLine(hSet.Count);
            Console.ReadKey();
        }
    }
}
