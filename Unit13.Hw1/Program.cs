using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit13.Hw1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var strList = new List<string>();
            var strLnkList = new LinkedList<string>();
            // читаем весь файл  в строку текста
            string text = File.ReadAllText("D:\\iLoad\\cdev_Text.txt");

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее ранее перечисленные символы-разделители
            // 
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // выводим количество
            Console.WriteLine("words.Length = {0}", words.Length);

            var stopWatch = Stopwatch.StartNew();
            foreach (var word in words)
            {
                strList.Add(word);

            }

            Console.WriteLine("stopWatch.Elapsed= {0} ms", stopWatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("strList.Count = {0}", strList.Count);

            var stopWatch1 = Stopwatch.StartNew();
            foreach (var word in words)
            {
                strLnkList.AddLast(word);

            }
            Console.WriteLine("stopWatch1.Elapsed= {0} ms", stopWatch1.Elapsed.TotalMilliseconds);
            Console.WriteLine("strLnkList.Count = {0}", strLnkList.Count);
            Console.ReadKey();
        }

    }
}
