using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6.Model
{
    class KaratsubaAlg
    {
        private int[] firstPolynom;
        private int[] secondPolynom;
        private int[] res;
        private ManualResetEvent manualReset = new ManualResetEvent(false);
        private AutoResetEvent autoReset = new AutoResetEvent(false);

        public KaratsubaAlg(int[] firstPolynom, int[] secondPolynom)
        {
            this.firstPolynom = firstPolynom;
            this.secondPolynom = secondPolynom;
            res = new int[this.firstPolynom.Length + this.secondPolynom.Length - 1];
        }
        public int[] GetRes() { return this.res; }

        public void InitThreads(int code)
        {
            if (this.firstPolynom.Length > 1)
            {
                if (code.Equals(1))
                {
                    ThreadPool.SetMaxThreads(1, 1);
                    ThreadPool.QueueUserWorkItem(
                        new WaitCallback(
                                            (_) =>
                                            {
                                                this.res = KaratsubaSeq(this.firstPolynom, this.secondPolynom);
                                                manualReset.Set();
                                            }
                                        ));
                    manualReset.WaitOne();
                }
                if (code.Equals(2))
                {
                    ThreadPool.SetMaxThreads(this.firstPolynom.Length, this.firstPolynom.Length);
                    KaratsubaN();
                }
                if (code.Equals(3))
                {
                    ThreadPool.SetMaxThreads(this.firstPolynom.Length * this.secondPolynom.Length, this.firstPolynom.Length * this.secondPolynom.Length);
                    KaratsubaN();
                }
            }
            else
                this.res[0] = this.firstPolynom[0] * this.secondPolynom[0]; 
        }

        private int[] SeqMultiplication(int[] firstPolynom, int[] secondPolynom)
        {
            int[] result = new int[firstPolynom.Length + secondPolynom.Length - 1]; 
            for (int i = 0; i < firstPolynom.Length; i++)
                for (int j = 0; j < secondPolynom.Length; j++)
                    result[i + j] += firstPolynom[i] * secondPolynom[j];
            return result;
        }

        private int[] KaratsubaSeq(int[] firstPolynom, int[] secondPolynom)
        {
            Debug.WriteLine(firstPolynom.Length + " " + secondPolynom.Length);
            var len = firstPolynom.Length;
            int[] result = new int[firstPolynom.Length + secondPolynom.Length - 1];
            int k = len / 2;

            int[] fLow = new int[k];
            int[] sLow = new int[k];
            int[] fHigh;
            int[] sHigh;
            if (this.firstPolynom.Length % 2 == 0)
            {

                fHigh = new int[k];
                sHigh = new int[k];
            }
            else
            {
                fHigh = new int[this.firstPolynom.Length - k];
                sHigh = new int[this.firstPolynom.Length - k];
            }
            
            for (int i= 0; i < k; i++)
            {
                fLow[i] = firstPolynom[i];
                sLow[i] = secondPolynom[i];
            }
            for (int i = k; i < this.firstPolynom.Length; i++)
            {
                fHigh[i - k] = firstPolynom[i];
                sHigh[i - k] = secondPolynom[i];
            }

            int[] sfLow = SeqMultiplication(fLow,sLow);
            int[] sfHigh = SeqMultiplication(fHigh,sHigh);
            int[] sfMid1 = SeqMultiplication(fLow,sHigh);
            int[] sfMid2 = SeqMultiplication(fHigh,sLow);

            for (int i = 0; i < sfMid1.Length; i++)
                sfMid1[i] += sfMid2[i];


            for (int i = 0; i < sfLow.Length; i++)
                result[i] = sfLow[i];

            for (int i = 0; i < sfMid1.Length; i++)
                result[i + k] = sfMid1[i];

            for (int i = 0; i < sfHigh.Length; i++)
                result[i + (2 * k)] += sfHigh[i];

            return result;
        }

        private void KaratsubaN()
        {
            int len = this.firstPolynom.Length;

            int k = len / 2;

            int[] fLow = new int[k];
            int[] sLow = new int[k];
            int[] fHigh;
            int[] sHigh;
            if (this.firstPolynom.Length % 2 == 0)
            {

                fHigh = new int[k];
                sHigh = new int[k];
            }
            else
            {
                fHigh = new int[this.firstPolynom.Length - k];
                sHigh = new int[this.firstPolynom.Length - k];
            }

            for (int i = 0; i < k; i++)
            {
                ThreadPool.QueueUserWorkItem(
                    new WaitCallback(
                                       (_) =>
                                       {
                                           fLow[i] = firstPolynom[i];
                                           sLow[i] = secondPolynom[i];
                                           autoReset.Set();
                                       }
                    ));
                autoReset.WaitOne();
            }
            for (int i = k; i < this.firstPolynom.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(
                    new WaitCallback(
                                       (_) =>
                                       {
                                           fHigh[i - k] = firstPolynom[i];
                                           sHigh[i - k] = secondPolynom[i];
                                           autoReset.Set();
                                       }
                    ));
                autoReset.WaitOne();
            }

            int[] sfLow = SeqMultiplication(fLow, sLow);
            int[] sfHigh = SeqMultiplication(fHigh, sHigh);
            int[] sfMid1 = SeqMultiplication(fLow, sHigh);
            int[] sfMid2 = SeqMultiplication(fHigh, sLow);

            for (int i = 0; i < sfMid1.Length; i++)
                sfMid1[i] += sfMid2[i];

            for (int i = 0; i < sfLow.Length; i++)
            {
                int index = i;
                ThreadPool.QueueUserWorkItem(
                   new WaitCallback(
                                      (_) =>
                                      {
                                          res[index] = sfLow[index];
                                          autoReset.Set();
                                      }
                    ));
                autoReset.WaitOne();
            }

            for (int i = 0; i < sfMid1.Length; i++)
            {
                int index = i;
                ThreadPool.QueueUserWorkItem(
                  new WaitCallback(
                                     (_) =>
                                     {
                                         res[index + k] = sfMid1[index];
                                         autoReset.Set();
                                     }
                    ));
                autoReset.WaitOne();
            }

            for (int i = 0; i < sfHigh.Length; i++)
            {
                int index = i;
                ThreadPool.QueueUserWorkItem(
                 new WaitCallback(
                                    (_) =>
                                    {
                                        res[index + (2 * k)] += sfHigh[index];
                                        autoReset.Set();
                                    }
                    ));
                autoReset.WaitOne();
            }
        }
    }
}
