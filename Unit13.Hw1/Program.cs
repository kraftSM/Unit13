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
        static bool rqExit = false;
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

            while (!rqExit)
            {
                Console.WriteLine("Press a key, together with Alt, Ctrl, or Shift.");
                Console.WriteLine("Введите команду \n\tNumPad0-Clear all Lists,\n\tNumPad1-List, \n\tNumPad2-LinkedList, \n\tNumPad3,Q,ESC - Выход");
                //Console.WriteLine("Press Esc to exit.");
                ConsoleKeyInfo input = Console.ReadKey(true);
                StringBuilder output = new StringBuilder(  String.Format("\nYou pressed [{0}]", input.Key.ToString()));
                if ((input.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt) output.Append("+ALT");
                if ((input.Modifiers & ConsoleModifiers.Shift) == ConsoleModifiers.Shift) output.Append("+SFT");
                if ((input.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control) output.Append("+CNT");
                Console.WriteLine(output);
                if ( input.Key == ConsoleKey.Escape) rqExit= true;
                else
                {
                    switch (input.Key) 
                    { 
                        case ConsoleKey.NumPad0:
                            Console.WriteLine("\nClear all Lists...");
                            Console.WriteLine("strList.Count = {0}", strList.Count);
                            Console.WriteLine("strLnkList.Count = {0}", strLnkList.Count);                            

                            var stopWatch0 = Stopwatch.StartNew();
                                strList.Clear();
                                strLnkList.Clear();
                            Console.WriteLine("Cleared. stopWatch0.Elapsed= {0} ms", stopWatch0.Elapsed.TotalMilliseconds);
                            Console.WriteLine("strList.Count = {0}", strList.Count);
                            Console.WriteLine("strLnkList.Count = {0}", strLnkList.Count);
                            break;
                        case ConsoleKey.NumPad1:
                            Console.WriteLine(" List...");

                            var stopWatch = Stopwatch.StartNew();
                            foreach (var word in words)
                            {
                                strList.Add(word);
                            }
                            Console.WriteLine("\nstopWatch.Elapsed= {0} ms", stopWatch.Elapsed.TotalMilliseconds);
                            Console.WriteLine("strList.Count = {0}", strList.Count);
                            break;
                        case ConsoleKey.NumPad2:
                            Console.WriteLine(" LinkedList...");                            
                            var stopWatch1 = Stopwatch.StartNew();
                            foreach (var word in words)
                            {
                                strLnkList.AddLast(word);
                            }
                            Console.WriteLine("\nstopWatch1.Elapsed= {0} ms", stopWatch1.Elapsed.TotalMilliseconds);
                            Console.WriteLine("strLnkList.Count = {0}", strLnkList.Count);
                            break;
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.Q:
                            rqExit = true;
                            Console.WriteLine("Exit...");
                            break;
                        default:
                            //Console.WriteLine("Введите команду \n\tNumPad0-Clear all Lists,\n\tNumPad1-List, \n\tNumPad2-LinkedList, \n\tNumPad3,Q,ESC - Выход");
                            Console.WriteLine("Sorry invalid command");
                            break;
                    }          

                }   
            }
        }

    }
}
