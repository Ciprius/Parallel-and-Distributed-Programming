using Lab7.Problem1;
using Lab7.Problem2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            View view = new View();
            View2 view2 = new View2();

            while (true)
            {
                Console.WriteLine("0: exit");
                Console.WriteLine("1: problem_1");
                Console.WriteLine("2: problem_2");
                Console.Write("Input:");
                string option = Console.ReadLine();

                if (option.Equals("0"))
                    break;
                if (option.Equals("1"))
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    view.ShowUI();
                    stopwatch.Stop();
                    view.ShowResult();
                    Console.WriteLine("Time: " + stopwatch.Elapsed.ToString() + " sec");
                    Console.WriteLine();
                }
                if (option.Equals("2"))
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    view2.ShowUI();
                    stopwatch.Stop();
                    view2.ShowResult();
                    Console.WriteLine("Time: " + stopwatch.Elapsed.ToString() + " sec");
                    Console.WriteLine();
                }
            }
        }
    }
}
