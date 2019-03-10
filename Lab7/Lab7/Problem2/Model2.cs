using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7.Problem2
{
    class Model2
    {
        private List<int[]> numbers;
        private Thread[] threads;
        private LinkedList<int[]> queue = new LinkedList<int[]>();
        private int globalLength = 0;
        private int localLength = 0;
        private int k = 0;
        private Mutex mutex = new Mutex();
        private AutoResetEvent resetEvent = new AutoResetEvent(false);

        public Model2(List<int[]> numbers)
        {
            this.numbers = numbers;
            Threads = new Thread[this.numbers.Count - 1];
            Compute();
        }

        public List<int[]> GetNumbers() { return this.numbers; }
        public int[] GetResult() { return queue.ElementAt(0); }
        public Thread[] Threads { get => threads; set => threads = value; }


        public void Compute()
        {
            for(int i = 0; i < this.numbers.Count - 1; i = i + 2)
            {
                int index = i;
                void threadStart() => ComputeNumber(this.numbers[index], this.numbers[index + 1]);
                threads[k] = new Thread(threadStart);
                threads[k].Start();
                k++;
            }
            for (; k < threads.Length;k++)
            {
                void threadStart() => ComputeN();
                threads[k] = new Thread(threadStart);
                threads[k].Start();
            }
        }

        private void ComputeNumber(int[] first,int[] second)
        {
            int[] sum = new int[15];
            int c = 0;
            int j;
            for (j = 0; j < second.Length; j++)
            {
                int elem = first[first.Length - 1 - j] + second[second.Length - 1 - j] + c;
                sum[sum.Length - 1 - j] = elem % 10;
                if (elem > 9)
                    c = 1;
                else
                    c = 0;
            }

            if (!first.Length.Equals(15))
            {
               sum[sum.Length - 1 - j] += c;
            }
            mutex.WaitOne();
            this.queue.AddFirst(sum);
            this.globalLength++;
            this.localLength = this.queue.Count;
            if (localLength.Equals(2))
                resetEvent.Set();
            mutex.ReleaseMutex();
        }

        private void ComputeN()
        {
            resetEvent.WaitOne();
            if (!this.globalLength.Equals(this.numbers.Count - 1))
            {
                int[] firstelem = this.queue.ElementAt(0);
                int[] secondelem = this.queue.ElementAt(1);
                this.queue.RemoveFirst();
                this.queue.RemoveFirst();
                this.localLength = this.queue.Count;
                ComputeNumber(firstelem, secondelem);
            }
        }

    }
}
