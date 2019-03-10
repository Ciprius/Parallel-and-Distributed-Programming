using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2.Model
{
    abstract class MatrixOperations
    {
        protected Thread[] threads;
        protected Matrix matrix;
        protected Matrix matrix1;
        protected Matrix matrix2;
        protected Mutex mutex = new Mutex();
        protected List<Tuple<int, int>> tuples;
        protected int size;

        public Matrix GetMatrix() { return this.matrix; }
        public Thread[] GetThreads() { return this.threads; }
        public abstract void SetNoThreads(int Code);
        public abstract void Add();
        public abstract void Mul();
        protected bool Check(int rowIndex, int colIndex)
        {
            foreach (Tuple<int, int> tuple in this.tuples)
                if (tuple.Item1.Equals(rowIndex) && tuple.Item2.Equals(colIndex))
                    return false;
            return true;
        }
    }
}
