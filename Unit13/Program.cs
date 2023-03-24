using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit13
{
    internal class Program
    {
        //static string FilePath = "D:\\WinTemp\\SkillFactory\\Добавление - изменение типа договора (документа).txt";
        //static string FilePath = "D:\\WinTemp\\SkillFactory\\Test file.txt";
        //static string FilePath = "C:\\Users\\Sergey.RSFGT\\Desktop\\SkillFactory\\get files from SP.txt";
        //static string FilePath = "D:\\iLoad\\cdev_Text.txt";
        static string FilePath = "R:\\Отделы\\it\\Kiselev\\SkillFactory\\cdev_Text.txt";


        static string SolutionRoot;
        static int CharCount = 0;
        static int LetterCount = 0;
        static int SpaceCount = 0;
        static int TabCount = 0;
        static int NewLineCount = 0;

        public static string GetSolutionRoot()
        {
            var dir = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            var fullname = Directory.GetParent(dir).FullName;
            var projectRoot = fullname.Substring(0, fullname.Length - 4);
            return Directory.GetParent(projectRoot)?.FullName;
        }
        public static string CheckArgs()
        {
            var dir = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            var fullname = Directory.GetParent(dir).FullName;
            var projectRoot = fullname.Substring(0, fullname.Length - 4);
            return Directory.GetParent(projectRoot)?.FullName;
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            { Console.WriteLine("Arg[{0}]= \"{1}\"  ", i, args[i]); };
            SolutionRoot = GetSolutionRoot();
            Console.WriteLine("SolutionRoot= {0}", SolutionRoot);

            //string filePath = @"/Users/luft/SkillFactory/Students.txt"; // Укажем путь 
            if (!File.Exists(FilePath)) // Проверим, существует ли файл по данному пути
            {
                //   Если не существует - создаём и записываем в строку
                using (StreamWriter sw = File.CreateText(FilePath))  // Конструкция Using (будет рассмотрена в последующих юнитах)
                {
                    sw.WriteLine("Олег");
                    sw.WriteLine("Дмитрий");
                    sw.WriteLine("Иван");
                }
            }
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
                        default: LetterCount++; break; //continue;
                    }

                    if (CharCount % 100 == 0)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.Write("Обработано:{0,10}", CharCount);

                        //Console.WriteLine("CharCount: {0} ", CharCount); // 
                    }
                }

            }
            Console.WriteLine("\nFinishing");
            Console.WriteLine("SpaceCount: {0} ", SpaceCount);
            Console.WriteLine("TabCount: {0} ", TabCount);
            Console.WriteLine("NewLineCount: {0} ", NewLineCount);
            Console.WriteLine("LetterCount: {0} ", LetterCount);
            Console.WriteLine("CharCount: {0} ", CharCount);

            Console.ReadKey();
        }
    }
}
