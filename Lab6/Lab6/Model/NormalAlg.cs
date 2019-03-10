using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Lab6.Model
{
    class NormalAlg
    {
        private int[] firstPolynom;
        private int[] secondPolynom;
        private int[] res;
        private Mutex mutex = new Mutex();

        public NormalAlg(int[] firstPolynom, int[] secondPolynom)
        {
            this.firstPolynom = firstPolynom;
            this.secondPolynom = secondPolynom;
            res = new int[this.firstPolynom.Length + this.secondPolynom.Length - 1];
        }

        public int[] GetRes() {
            foreach (int i in res)
            {
                Debug.WriteLine(i);
            }
            return this.res; }

        public void InitThreads(int code)
        {
            if (code.Equals(1))
            {
                ThreadPool.SetMaxThreads(1,1);
                ThreadPool.QueueUserWorkItem(new WaitCallback(SeqMultiplication),1);
            }
            if (code.Equals(2))
            {
                ThreadPool.SetMaxThreads(this.firstPolynom.Length, this.firstPolynom.Length);
                for (int i = 0; i < this.firstPolynom.Length; i++)
                {
                    int thindex = i;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(NMultiplication), thindex);
                }
            }
            if (code.Equals(3))
            {
                ThreadPool.SetMaxThreads(this.firstPolynom.Length*this.secondPolynom.Length , this.firstPolynom.Length * this.secondPolynom.Length);
                for (int i = 0; i < this.firstPolynom.Length; i++)
                {
                    int indexI = i;
                    for (int j = 0; j < this.secondPolynom.Length; j++)
                    {
                        int indexJ = j;
                        ThreadPool.QueueUserWorkItem(new WaitCallback(NxMMultiplication), new Tuple<int,int>(indexI,indexJ));
                    }
                }
            }
        }

        private void SeqMultiplication(object obj)
        {
            for (int i = 0; i < this.firstPolynom.Length; i++)
                for (int j = 0; j < this.secondPolynom.Length; j++)
                    this.res[i + j] += this.firstPolynom[i] * this.secondPolynom[j];
        }

        private void NMultiplication(object index)
        {
            int indx = Convert.ToInt32(index);
            for (int j = 0; j < this.secondPolynom.Length; j++)
            {
                this.res[indx + j] += this.firstPolynom[indx] * this.secondPolynom[j];
            }
        }

        private void NxMMultiplication(object tupl)
        {
            var tuple = tupl as Tuple<int, int>;
            this.res[tuple.Item1 + tuple.Item2] += this.firstPolynom[tuple.Item1] * this.secondPolynom[tuple.Item2];
        }
    }
}
