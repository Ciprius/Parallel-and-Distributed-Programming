using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab8
{
    class Model
    {
        private Thread[] threads;
        private int nrV;
        private Dictionary<int, int[]> paths;
        private int[] path;
        private int ok = 0;
        private Mutex mutex = new Mutex();

        public Model(int nrT, int nrV)
        {
            Threads = new Thread[nrT];
            NrV = nrV;
            Path = new int[nrV];
            Paths = new Dictionary<int, int[]>();
        }

        public Thread[] Threads { get => threads; set => threads = value; }
        public int NrV { get => nrV; set => nrV = value; }
        public int[] Path { get => path; set => path = value; }
        public Dictionary<int, int[]> Paths { get => paths; set => paths = value; }

        private bool IsSafe(int elem, int[,] graph, int[] path, int pos)
        {
            if (graph[path[pos - 1], elem].Equals(0))
                return false;

            for (int i = 0; i < pos; i++)
                if (path[i].Equals(elem))
                    return false;
            return true;
        }
        
        private bool HamCycleUtil(int[,] graph, int[] path, int pos)
        {
            if (pos == NrV)
            {
                if (graph[path[pos - 1], path[0]] == 1)
                    return true;
                else
                    return false;
            }

            for (int v = 0; v < NrV; v++)
            {
                if (IsSafe(v, graph, path, pos))
                {
                    path[pos] = v;
                    if (HamCycleUtil(graph, path, pos + 1) == true)
                        return true;
                    int item = path[pos];
                    path = path.Where(val => val != item).ToArray();
                }
            }
            return false;
        }

        private void HamCycle(int item,int[,] graph)
        {
            int[] pat = new int[NrV];
            for (int i = 0; i < NrV; i++)
                pat[i] = -1;
            pat[0] = item;
            Paths.Add(item,pat);

            if (HamCycleUtil(graph, Paths[item], 1))
            {
                mutex.WaitOne();
                if (ok.Equals(0))
                {
                    ok = 1;
                    Path = Paths[item];
                }
                mutex.ReleaseMutex();
            }
        }

        public void Start(int[,] graph)
        {
            for (int i = 0; i < NrV; i++)
            {
                int elem = i;
                void threadStart() => HamCycle(elem, graph);
                Threads[elem] = new Thread(threadStart);
                Threads[elem].Start();
            }
        }
    }
}
