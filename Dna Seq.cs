using System;
using System.Collections.Generic;
using System.Text;

namespace ACGT
{
    class Program
    {
        public static string encodeDna(string toconv)
        {
            string sequenze = "";
            var myDict = new Dictionary<string, string>(){
                {"A", "00"},
                {"T", "01"},
                {"C", "10"},
                {"G", "11"}
            };
            try
            {
                foreach (char c in toconv)
                {
                    sequenze = sequenze + myDict[c.ToString()];
                }
                Console.WriteLine("Converting succesfull...");
                return sequenze;
            }
            catch
            {
                Console.WriteLine("Exit");
                Environment.Exit(0);
                return "0";
            }
        }

        public static string decodeDna(string toconv)
        {
            var myDict = new Dictionary<string, string>(){
                {"00", "A"},
                {"01", "T"},
                {"10", "C"},
                {"11", "G"}
            };
            return myDict[toconv];
        }
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
        public static string doubleHelix(string toconv)
        {
            string sequenze = "";
            var myDict = new Dictionary<string, string>(){
                {"A", "T"},
                {"T", "A"},
                {"C", "G"},
                {"G", "C"}
            };
            try
            {
                foreach (char c in toconv)
                {
                    sequenze = sequenze + myDict[c.ToString()];
                }
                //Console.WriteLine("Converting succesfull...");
                return sequenze;
            }
            catch
            {
                Console.WriteLine("Exit");
                Environment.Exit(0);
                return "0";
            }
        }

        static void Main(string[] args)
        {
            //Console.Write("Acgt Seq to Bin: ");
            // string BinSeq = encodeDna(Console.ReadLine().ToUpper());
            // Console.WriteLine(BinSeq);
            Console.Write("String Seq to Bin: ");
            string BinSeq = StringToBinary(Console.ReadLine());
            string c = "";
            for (int i = 1; (i - 1) / 2 < BinSeq.Length; i += 2)
            {
                try
                {
                    c = c + decodeDna(Convert.ToString(BinSeq[i-1]) + Convert.ToString(BinSeq[i]));
                }
                catch
                {
                }
            }

            Console.WriteLine("Dna seq: {0}", c);
            Console.WriteLine("Binary seq {0}", BinSeq);

            Console.WriteLine();
            Console.WriteLine(("Double Helix"));
            Console.WriteLine(c);
            Console.WriteLine(doubleHelix(c));
            Console.WriteLine();

            Console.WriteLine("Input seq: {0}", BinaryToString(BinSeq));
            Console.ReadKey();

        }
    }
}