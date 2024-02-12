using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] students = new string[3];
            students[0] = "engin";
            students[1] = "berin";
            students[2] = "semih";
            string[] students2 = new[] { "Engin", "Beril", "Semih" };



            foreach (var student in students2)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        string[,] regions = new string[5, 3]
        {
            { "istanbul", "izmit", "Balıkesir" },
            { "ankara", "konya", "kırıkkale" },
            { "rize", "trabzon", "samsun" },
            { "antalya", "adana", "mersin" },
            { "izmir", "muğla", "manisa" }
        };
        for (int i = 0; i < regions.GetUpperBound(0); i++)
        {
            for(int j = 0; j <regions.GetUpperBound(1); j++);

         }

        
       
    
    
    
}
