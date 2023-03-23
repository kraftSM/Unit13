using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Unit13.Hw2
{
    internal class Program    
    {
        static void Main(string[] args)
        {
            const int MaxWordPrintCnt = 550; // Number of Top word printing info 
            //var strList = new List<string>();
            var WordsNum = new Dictionary<string, WordInfo>();
            //var WordsNum = new SortedDictionary<string, WordInfo>();

            // читаем весь файл с рабочего стола в строку текста
            string text = File.ReadAllText("D:\\iLoad\\cdev_Text.txt");
            //string text = File.ReadAllText("C:\\Users\\Eugene\\Desktop\\Text.txt");

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '.', '?','!', ',', ':', ';', '-', '_', '=', '+', '"', '/', '\\', '<', '>',  '(', ')','\r', '\n' }; // 

            // разбиваем нашу строку текста, используя ранее ранее перечисленные символы-разделители
            // 
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // выводим количество
            Console.WriteLine("words.Length = {0}", words.Length);

            var stopWatch = Stopwatch.StartNew();
            foreach (var word in words)
            {
                WordInfo wrdCount;
                bool Finded = WordsNum.TryGetValue(word, out wrdCount);
                if (!Finded)
                {
                    var NewWrdCount = new WordInfo(word, 1);
                    //wrdCount.Word = word;
                    //wrdCount.Count = 1;
                    WordsNum.Add(word, NewWrdCount);
                }
                else
                    wrdCount.Count++;
            }
            Console.WriteLine("stopWatch.Elapsed= {0} ms", stopWatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("WordsNum.Count = {0:E}", WordsNum.Count);
            Console.WriteLine("Press a key..."); Console.ReadKey();

            //foreach (var wrd in WordsNum)
            //{ Console.WriteLine("WordsNum: {0}", wrd); }

            var stopWatch1 = Stopwatch.StartNew();
            List<WordInfo> WordsNumList = new List<WordInfo>();
            WordsNumList = WordsNum.Values.ToList();

            Console.WriteLine("WordsNumList.Count = {0}", WordsNumList.Count);

            WordsNumList.Sort((WordInfo x, WordInfo y) =>
                x.Count == null && y.Count == null
                    ? 0
                    : x.Count == null
                        ? -1
                        : y.Count == null
                            ? 1
                            : (x.Count > y.Count)
                                ? -1
                                : (x.Count < y.Count)
                                    ? 1
                                    : x.Word.CompareTo(y.Word));
            //for ( int i=0; i < WordsNumList.Count;i++ )
            Console.WriteLine("WordsNumList sorted" );
            Console.WriteLine("stopWatch1.Elapsed= {0:E} ms", stopWatch1.Elapsed.TotalMilliseconds);
            Console.WriteLine("Press a key..."); Console.ReadKey();

            for (int i = 0; i < MaxWordPrintCnt; i++)
            { Console.WriteLine("WordsNumList{0,4}: {1}", i,WordsNumList[i]); }


            //foreach (var wrd in WordsNumList)
            //{ Console.WriteLine("WordsNumList: {0}", wrd); }

            Console.WriteLine("Press a key..."); Console.ReadKey();
            //}

        }
    }
}
