using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Problem1
{
    class View
    {
        private Models model;

        public View() {}

        public void ShowUI()
        {
            Console.Write("Give the number of threads: ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("Give the length: ");
            int numSize = int.Parse(Console.ReadLine());
            InitData(size,numSize);
        }

        private void InitData(int threadSize,int numSize)
        {
            List<int> items = new List<int>();
            Random random = new Random();

            while (numSize != 0 )
            {
                items.Add(random.Next(1,10));
                numSize--;
            }
            this.model = new Models(items,threadSize);
        }

        public void ShowResult()
        {
            Console.Write("Input:");
            for (int i = 0; i < this.model.GetFirstSequence().Count; i++)
            {
                Console.Write("{0}{1}", this.model.GetFirstSequence()[i], i+1 == this.model.GetFirstSequence().Count ? "\n" : ",");
            }
            Console.Write("Result:");
            for (int i = 0; i < this.model.GetResult().Count; i++)
            {
                Console.Write("{0}{1}", this.model.GetResult()[i], i+1 == this.model.GetResult().Count ? "\n":",");
            }
        }
    }
}
