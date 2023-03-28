using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Unit13.Hw2V1
{
    internal class Program
    {
        //static string FilePath = "R:\\Отделы\\it\\Kiselev\\SkillFactory\\cdev_Text.txt";
        static string FilePath = "D:\\iLoad\\cdev_Text.txt";

        static string SolutionRoot;
        static int CharCount = 0;
        static int LetterCount = 0;
        static int SpaceCount = 0;
        static int TabCount = 0;
        static int NewLineCount = 0;
        static bool IsWord = false;
        static StringBuilder InputWord;
        static HashSet<char> vipChars; 

        static void Main(string[] args)
        {
            //const int MaxWordPrintCnt = 550; // Number of Top word printing info 
            const int MaxWordPrintCnt = 50; // Number of Top word printing info 
            //var strList = new List<string>();
            var WordsNum = new Dictionary<string, WordInfo>();
            InputWord = new StringBuilder();
            //var WordsNum = new SortedDictionary<string, WordInfo>();

            // читаем весь файл в строку текста
            string text = File.ReadAllText("D:\\iLoad\\cdev_Text.txt");

            //// Сохраняем символы-разделители в массив
            //char[] delimiters = new char[] { ' ', '.', '?', '!', ',', ':', ';', '-', '_', '=', '+', '"', '/', '\\', '<', '>', '(', ')', '\r', '\n' }; // 

            //// разбиваем нашу строку текста, используя ранее ранее перечисленные символы-разделители 
            //var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            //Console.WriteLine("words.Length = {0}", words.Length);
            vipChars = new HashSet<char>() { '.', '?', '!', ',', ':', ';', '-', '–', '_', '=', '+', '"', '/', '\\', '<', '>', '[', ']', '(', ')', '«', '»', '\r', '\n' };//' ', 
             //foreach(var ch in vipChars) Console.WriteLine(ch);

            if (File.Exists(FilePath)) // Проверим, существует ли файл по данному пути
            {
                // Откроем файл и прочитаем его содержимое
                using (StreamReader sr = File.OpenText(FilePath))
                {
                    // //Console.WriteLine(sr.EndOfStream);
                    // string str = "";
                    //while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
                    //{
                    //    Console.WriteLine(str);
                    //}

                    char inPutChar;
                    while (!sr.EndOfStream) // Пока не кончатся Символы - считываем из файла по одной и выводим в консоль
                    {
                        inPutChar = (char)sr.Read();
                        CharCount++;
                        switch (inPutChar)
                        {
                            case ' ': SpaceCount++; break; //continue;
                            case '\t': TabCount++; break; //continue;
                            case '\n': NewLineCount++; break; //continue;
                            default: 
                                LetterCount++;
                                if (!vipChars.Contains(inPutChar)) 
                                    InputWord.Append(inPutChar);    
                                break; //continue;
                        }

                        if (CharCount % 100 == 0)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.Write("Обработано:{0,10}", CharCount);

                            //Console.WriteLine("CharCount: {0} ", CharCount); // 
                        }
                        if (System.Char.IsSeparator(inPutChar) | System.Char.IsPunctuation(inPutChar) )
                        {
                            if (InputWord.Length > 0)
                                { 
                                IsWord = true;
                                MakeWordStatistic(InputWord.ToString(), WordsNum);
                                InputWord.Clear(); 
                            }
                        }
                        else IsWord = false;

                    }

                }
            }
            var stopWatch = Stopwatch.StartNew();
            //foreach (var word in words)
            //    MakeWordStatistic(word, WordsNum);
            
            Console.WriteLine("\n stopWatch.Elapsed= {0} ms", stopWatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("WordsNum.Count = {0}", WordsNum.Count);
            Console.WriteLine("Press a key..."); Console.ReadKey();

            //foreach (var wrd in WordsNum)
            //{ Console.WriteLine("WordsNum: {0}", wrd); }

            var stopWatch1 = Stopwatch.StartNew();
            List<WordInfo> WordsNumList = new List<WordInfo>();
            WordsNumList = WordsNum.Values.ToList();

            Console.WriteLine("WordsNumList.Count = {0}", WordsNumList.Count);
            //простой вариант Лямбды по сортировки, список делается из Dictionary, поэтому проверке на NULL не нужна
            WordsNumList.Sort((WordInfo x, WordInfo y) =>
                x.Count > y.Count
                        ? -1
                        : (x.Count < y.Count)
                            ? 1
                                : x.Word.CompareTo(y.Word));

            //for ( int i=0; i < WordsNumList.Count;i++ )
            Console.WriteLine("WordsNumList sorted");
            Console.WriteLine("stopWatch1.Elapsed= {0:E} ms", stopWatch1.Elapsed.TotalMilliseconds);
            Console.WriteLine("Press a key..."); Console.ReadKey();

            Console.WriteLine("\nFinishing");
            Console.WriteLine("SpaceCount: {0} ", SpaceCount);
            Console.WriteLine("TabCount: {0} ", TabCount);
            Console.WriteLine("NewLineCount: {0} ", NewLineCount);
            Console.WriteLine("LetterCount: {0} ", LetterCount);
            Console.WriteLine("CharCount: {0} ", CharCount);
            Console.WriteLine("Press a key..."); Console.ReadKey();

            Console.WriteLine("\nWord statistic is:");
            Console.WriteLine("StatListNaim Idx: Word = Word count");

            for (int i = 0; i < MaxWordPrintCnt; i++)
            { Console.WriteLine("WordsNumList{0,4}: {1}", i, WordsNumList[i]); }


            //foreach (var wrd in WordsNumList)
            //{ Console.WriteLine("WordsNumList: {0}", wrd); }

            Console.WriteLine("Press a key..."); Console.ReadKey();
            //}

        }
        public static void MakeWordStatistic(string word, Dictionary<string, WordInfo> WordsNum) 
        {
            WordInfo wrdCount;
            bool Finded = WordsNum.TryGetValue(word, out wrdCount);
            if (!Finded)
            {
                var NewWrdCount = new WordInfo(word, 1);
                WordsNum.Add(word, NewWrdCount);
            }
            else wrdCount.Count++;
        }
}

    }
    
