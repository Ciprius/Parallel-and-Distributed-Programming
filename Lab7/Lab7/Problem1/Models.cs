using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Lab7.Problem1
{
    class Models
    {
        private List<int> firstSequence;
        private List<int> result;
        private AutoResetEvent auto = new AutoResetEvent(false);
        private ManualResetEvent manual = new ManualResetEvent(false);

        public Models(List<int> sequence,int threadSize)
        {
            this.firstSequence = sequence;
            this.result = new List<int>();
            if (threadSize.Equals(1))
            {
                ThreadPool.SetMaxThreads(1,1);
                ThreadPool.QueueUserWorkItem(new WaitCallback(Sequntial),1);
            }
            else
            {
                for (int i = 0; i< this.firstSequence.Count; i++)
                {
                    int index = i;
                    ThreadPool.SetMaxThreads(threadSize, threadSize);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Parallel), index);
                }
            }
        }

        public List<int> GetResult() { return this.result; }
        public List<int> GetFirstSequence() { return this.firstSequence; }

        private void Sequntial(object obj)
        {
            for(int i = 0; i < this.firstSequence.Count; i++)
            {
                if (i.Equals(0))
                    this.result.Add(this.firstSequence[i]);
                else
                {
                    this.result.Add(this.firstSequence[i]+ this.result[i-1]);
                }
            }
        }

        private void Parallel(object obj)
        {
            int index = Convert.ToInt32(obj);

            if (index.Equals(0))
            {
                this.result.Add(this.firstSequence[0]);
                this.manual.Set();
            }
            else
            {
                this.manual.WaitOne();
                while (this.result.Count < index)
                {
                    //auto.WaitOne();
                }
                this.result.Add(this.firstSequence[index] + this.result[index - 1]);
                //auto.Set();
            }
        }
    }
}
