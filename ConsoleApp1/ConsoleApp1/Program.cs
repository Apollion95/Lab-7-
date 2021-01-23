using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        private static readonly Random random = new Random();
        public interface IPrintable
        {
            void Print();
        }
        class Lista : ICloneable, IComparable<Lista>, IPrintable
        {
            public int Id;
            public string Tekst;
            public int[] Tab = new int[10];
            public Lista(int Id, string Tekst, int[] Tab)
            {
                this.Id = Id;
                this.Tekst = Tekst;
                this.Tab = Tab;
            }
            public object Clone()
            {
                int[] Tablica = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    Tablica[i] = Tab[i];
                }
                return new Lista(Id, Tekst, Tablica);
            }
            public int CompareTo(Lista other)
            {
                return Tekst.CompareTo(other.Tekst);
            }
            public void Print()
            {
                Console.WriteLine($"Id: {Id}");
                Console.WriteLine($"Tekst: {Tekst}");
                for (int i = 0; i < Tab.Length; i++)
                {
                    Console.WriteLine($"Element tablicy [{i}] = {Tab[i]}");
                }
            }
        }
        public static void Wypisz()
        {
            Lista[] Lista = new Lista[100];

            for (int i = 0; i < 100; i++)
            {
                string text = "";
                int[] tablica = new int[10];
                for (int j = 0; j < 10; j++)
                {
                    tablica[j] = random.Next(1, 20);
                }
                for (int k = 0; k < 10; k++)
                {
                    text += (char)random.Next('a', 'z');
                }
                Lista[i] = new Lista(i, text, tablica);
            }
            List<Lista> Tab2 = new List<Lista>();
            for (int i = 0; i < 100; i++)
            {
                Tab2.Add((Lista)Lista[i].Clone());

                for (int j = 0; j < 10; j++)
                {
                    Lista[i].Tab[j] = 0;
                }
            }
            Tab2.Sort();
            for (int i = 0; i < 100; i++)
            {
                Tab2[i].Print();
            }
        }
        static void Main(string[] args)
        {
            Wypisz();
        }
    }
}