using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;
using MPIUtils;

namespace Lab9_Csharp
{
    [Serializable]
    public struct Polynoms
    {
        public int[] fvector;
        public int[] svector;
        public int[] result;
        public int i;
        public int j;
        
        public Polynoms(int cap)
        {
            i = 0;
            j = 0;
            fvector = new int[cap];
            svector = new int[cap];
            result = new int[cap * 2 - 1];
        }
    }

    class Program
    {
        private static Polynoms polynoms;
        private static Stopwatch stopWatch = new Stopwatch();
        static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                Intracommunicator comm = Communicator.world; polynoms = new Polynoms(comm.Size);

                if (comm.Rank.Equals(0))
                {
                    polynoms = new Polynoms(comm.Size);
                    Random random = new Random();
                    for (int i = 0; i < polynoms.svector.Length; i++)
                    {
                        polynoms.fvector[i] = random.Next(1, 2);
                        polynoms.svector[i] = random.Next(1, 2);
                    }
                    Show(polynoms.fvector,polynoms.svector);
                    stopWatch.Start();
                }

                comm.Broadcast(ref polynoms, 0);

                for (polynoms.i = 0; polynoms.i < comm.Size; polynoms.i++)
                {
                    polynoms.j = 0;
                    if (comm.Rank.Equals(0))
                    {
                        comm.Send(polynoms, 1, 0);
                        polynoms = comm.Receive<Polynoms>(Communicator.anySource, 0);
                        polynoms.result[polynoms.i + polynoms.j] += polynoms.fvector[polynoms.i] * polynoms.svector[polynoms.j];
                    }
                    else
                    {
                        polynoms = comm.Receive<Polynoms>(comm.Rank - 1, 0);
                        polynoms.result[polynoms.i + polynoms.j] += polynoms.fvector[polynoms.i] * polynoms.svector[polynoms.j];
                        polynoms.j++;
                        comm.Send(polynoms, (comm.Rank + 1) % comm.Size, 0);
                    }
                }

                if (comm.Rank.Equals(0))
                {
                    stopWatch.Stop();
                    for (int i = 0; i < polynoms.result.Length; i++)
                        Console.Write("{0}X^{1}{2}", polynoms.result[i],i, (i + 1) < polynoms.result.Length ? " + " : "\n");
                    Console.WriteLine("Time taken:{0} sec",stopWatch.Elapsed.ToString());
                }
            }
        }

        private static void Show(int[] first, int[] second)
        {
            for (int i = 0; i < first.Length; i++)
                Console.Write("{0}X^{1}{2}", first[i],i,(i+1) < first.Length ? " + ":"\n");
             
            for (int i = 0; i < second.Length; i++)
                Console.Write("{0}X^{1}{2}", second[i],i, (i + 1) < second.Length ? " + " : "\n");
            Console.WriteLine();
        }
    }
}

