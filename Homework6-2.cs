using System;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input the number: ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("This number's prime factor is : ");
            int PrimeFactor = 2;
            while (num != 1)
            {
                while(num%PrimeFactor == 0)
                {
                    Console.Write("{0}, ",PrimeFactor);
                    num = num / PrimeFactor;
                }
                PrimeFactor += 1;

            }

        }
    }
}
