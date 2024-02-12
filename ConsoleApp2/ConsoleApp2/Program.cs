using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sayi1 = 20;
            //if (sayi1 < 100)
            //{
            //    Console.WriteLine("sayı yüzden küçük");
            //}
            //else if (sayi1 ==100)
            //{
            //    Console.WriteLine("sayı yüze eşittir");
            //}
            //else
            //{
            //    Console.WriteLine("sayı yüzden küçük değildir");
            //}
            //Console.ReadLine();
            //switch (sayi1)
            //{
            //    case 100:
            //        Console.WriteLine("sayı yüzdür");
            //        break;
            //    case 200:
            //        Console.WriteLine("sayı iki yüzdür");
            //        break;
            //    default:
            //        Console.WriteLine("sayı ne yüz ne de iki yüzdür");
            //        break;

            //}


            if (sayi1 > 0 && sayi1 < 100) 
            {
                Console.WriteLine("sayi onluktur");
            
            }
            else if (sayi1 >= 100 && sayi1 < 1000) 
            {
            Console.WriteLine("sayı yüzlüktür");
            }




            Console.ReadLine();


        }
    }
}

