using Lab6.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        private static int length;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("0: exit");
                Console.Write("Give the length of the polynoms:");
                length = int.Parse(Console.ReadLine());
                if (length.Equals(0))
                    break;

                while (true)
                {
                    Console.WriteLine("0: exit");
                    Console.WriteLine("1: Normal");
                    Console.WriteLine("2: Karatsuba");
                    Console.Write("Input: ");
                    string option = Console.ReadLine();

                    if (option.Equals("0"))
                        break;
                    if (option.Equals("1"))
                        NormalMenu();
                    if (option.Equals("2"))
                        KaratsubaMenu();
                }
            }
        }

        static void NormalMenu()
        {
            Stopwatch stopWatch = new Stopwatch();
            Cont cont = new Cont(length, length);
            while (true)
            {
                Console.WriteLine("0: exit");
                Console.WriteLine("1: 1 Thread");
                Console.WriteLine("2: N Threads");
                Console.WriteLine("3: NxM Threads");
                Console.Write("Input:");
                string option = Console.ReadLine();

                if (option.Equals("0"))
                    break;
                if (option.Equals("1"))
                {
                    Console.WriteLine("Normal:");
                    stopWatch.Start();
                    cont.InitNormal(1);
                    cont.ShowResNor();
                    stopWatch.Stop();
                    Console.WriteLine(stopWatch.Elapsed.ToString() + " sec");
                }
                if (option.Equals("2"))
                {
                    Console.WriteLine("Normal:");
                    stopWatch.Start();
                    cont.InitNormal(2);
                    cont.ShowResNor();
                    stopWatch.Stop();
                    Console.WriteLine(stopWatch.Elapsed.ToString() + " sec");
                }
                if (option.Equals("3"))
                {
                    Console.WriteLine("Normal:");
                    stopWatch.Start();
                    cont.InitNormal(3);
                    cont.ShowResNor();
                    stopWatch.Stop();
                    Console.WriteLine(stopWatch.Elapsed.ToString() + " sec");
                }
                Console.WriteLine();
            }
        }

        static void KaratsubaMenu()
        {
            Stopwatch stopWatch = new Stopwatch();
            Cont cont = new Cont(length, length);
            while (true)
            {
                Console.WriteLine("0: exit");
                Console.WriteLine("1: 1 Thread");
                Console.WriteLine("2: N Threads");
                Console.WriteLine("3: NxM Threads");
                Console.Write("Input:");
                string option = Console.ReadLine();

                if (option.Equals("0"))
                    break;
                if (option.Equals("1"))
                {
                    Console.WriteLine("NormalKaratsuba:");
                    stopWatch.Start();
                    cont.InitKaratsuba(1);
                    cont.ShowResKat();
                    stopWatch.Stop();
                    Console.WriteLine(stopWatch.Elapsed.ToString() + " sec");
                }
                if (option.Equals("2"))
                {
                    Console.WriteLine("Karatsuba:");
                    stopWatch.Start();
                    cont.InitKaratsuba(2);
                    cont.ShowResKat();
                    stopWatch.Stop();
                    Console.WriteLine(stopWatch.Elapsed.ToString() + " sec");
                }
                if (option.Equals("3"))
                {
                    Console.WriteLine("Karatsuba:");
                    stopWatch.Start();
                    cont.InitKaratsuba(3);
                    cont.ShowResKat();
                    stopWatch.Stop();
                    Console.WriteLine(stopWatch.Elapsed.ToString() + " sec");
                }
                Console.WriteLine();
            }
        }
    }
}
