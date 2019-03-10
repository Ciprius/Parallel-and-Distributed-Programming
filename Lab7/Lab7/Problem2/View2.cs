using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7.Problem2
{
    class View2
    {
        private Model2 model2;
        public View2() { }

        public void ShowUI()
        {
            Console.Write("Give the length: ");
            int numSize = int.Parse(Console.ReadLine());
            InitData(numSize);
        }

        private void InitData(int numSize)
        {
            List<int[]> items = new List<int[]>();
            Random random = new Random();

            while (numSize != 0)
            {
                int[] item = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    item[i] = random.Next(1, 10);
                }
                items.Add(item);
                numSize--;
            }
            this.model2 = new Model2(items);
        }

        public void ShowResult()
        {
            foreach (Thread th in this.model2.Threads)
            {
                th.Join();
            }
            Console.WriteLine("Input:");
            for (int i = 0; i < this.model2.GetNumbers().Count; i++)
            {
                int[] item = this.model2.GetNumbers()[i];
                for (int j = 0; j < item.Length;j++)
                    Console.Write("{0}{1}", item[j], j + 1 == item.Length ? "\n" : ",");
            }
            Console.Write("Result:");
            int ok = 0;
            for (int i = 0; i < this.model2.GetResult().Length; i++)
            {
                if (this.model2.GetResult()[i] != 0)
                    ok = 1;
                if (ok.Equals(1))
                    Console.Write("{0}{1}", this.model2.GetResult()[i], i + 1 == this.model2.GetResult().Length ? "\n" : ",");
            }
        }
    }
}
