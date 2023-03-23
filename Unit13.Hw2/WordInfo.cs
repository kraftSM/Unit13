using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit13.Hw2
{
    public class WordInfo // модель класса: IEquatable<WordInfo>, IComparable<WordInfo> , IEnumerable<WordInfo>
    {
        public WordInfo(String word, long count) // метод-конструктор
        {
            Count = count;
            Word = word;
        }
        public long Count { get; set; }
        public String Word { get; set; }
        public override string ToString()
        {
            if (Word.Length == 1)
            {
                //char[] Wrd = Word.ToCharArray();
                //double CharCode = (double)Char.GetNumericValue(Wrd[0]);
                //return " " + Word + "[" + CharCode.ToString()+ "]" + " = " + Count;
                return " " + Word + "[" + Word+ "]" + " = " + Count;

            }
            else 
                return " " + Word + " = " + Count;
        }

        ////public override int GetHashCode() => Word;
        //public override bool Equals(object obj) =>
        //(obj is WordInfo word_info)
        //        ? Equals(word_info)
        //        : false;
        //public bool Equals(WordInfo other) =>
        //other is null ? false : Count.Equals(other.Count);

        //public int CompareTo(WordInfo compareWI) =>
        //compareWI == null ? 1 : Count.CompareTo(compareWI.Count);

        //public int SortByNameAscending(string name1, string name2) =>
        //name1?.CompareTo(name2) ?? 1;

        //public IEnumerator<WordInfo> GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
