﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = 20;
            int number2 = 140;
            var result2 = Add3(ref number1, number2);


            var result = Add2(  );
            Console.WriteLine( Add4(2,4,6,3,5,7,9,3,6,7) );
            Console.WriteLine( number1 );
            Console.ReadLine();
        }
        static void Add ()
        {
            Console.WriteLine("Added");
        }

        static int Add2(int number1=20 , int number2=30)
        {
            var result = number1 + number2;
            return result;
        }
        static int Add3(ref int number1 , int number2) 
        {
            number1 = 30;
            return number1 + number2;
        }
        static int Multiply(int number1 , int number2) 
        {
            return number1 * number2;
        }
        static int Multiply(int number1, int number2 , int number3) 
        {
            return number1 * number2 * number3;
        }
        static int Add4 (params int [] numbers) 
        {
            return numbers.Sum();
        }

    }
}
