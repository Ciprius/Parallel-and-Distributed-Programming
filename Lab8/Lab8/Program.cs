using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("0:exit");
                Console.WriteLine("1: continue");
                string option = Console.ReadLine();

                if (option.Equals("0"))
                    break;
                if (option.Equals("1"))
                {
                    Console.Write("Give the nr of vertices:");
                    int nrV = Convert.ToInt32(Console.ReadLine());
                    //Console.Write("Give the nr of threads:");
                    //int nrT = Convert.ToInt32(Console.ReadLine());
                    Generate(nrV, nrV); 
                }
            }
        }

        static void Generate(int nrV, int nrT)
        {
            int[,] graph = new int[nrV,nrV];
            Random random = new Random();

            for (int i = 0; i < nrV; i++)
                for (int j = i; j < nrV; j++)
                    if (i.Equals(j))
                        graph[i, j] = 0;
                    else
                    {
                        graph[i, j] = random.Next(2);
                        graph[j, i] = graph[i,j];
                    }
            for (int i = 0; i < nrV; i++)
            {
                for (int j = 0; j < nrV; j++)
                    Console.Write(graph[i, j] + " ");
                Console.WriteLine();
            }

            Model model = new Model(nrT,nrV);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            model.Start(graph);
            foreach (Thread th in model.Threads)
                th.Join();
            stopwatch.Stop();
            Show(model.Path);
            Console.WriteLine("Time taken: {0} sec",stopwatch.Elapsed.ToString());
        }

        static void Show(int[] res)
        {
            Console.WriteLine("The result: ");
            foreach (int i in res)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}
