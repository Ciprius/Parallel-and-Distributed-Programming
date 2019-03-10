using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2.Model
{
    class MatrixAddition : MatrixOperations
    {
        public MatrixAddition(int size, Matrix matrix1, Matrix matrix2)
        {
            this.matrix = new Matrix(size, size);
            this.tuples = new List<Tuple<int, int>>();
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
        }
        public override void Add(){}
        public override void Mul(){}

        private void InitThreads()
        {
            if (this.threads.Length.Equals(1))
            {
                this.threads[0] = new Thread(new ThreadStart(AddMatrixSeq));
                this.threads[0].Start();
            }

            if (this.threads.Length.Equals(this.matrix.GetNoRows()))
            {
                for (int i = 0; i < threads.Length; i++)
                {
                    int threadIndex = i;
                    ThreadStart start = () => AddMatrix(threadIndex);
                    this.threads[threadIndex] = new Thread(start);
                    this.threads[threadIndex].Start();
                }
            }

            if (this.threads.Length.Equals(this.matrix.GetNoRows() * this.matrix.GetNoColumns()))
            {
                for (int i = 0; i < threads.Length; i++)
                {
                    int threadIndex = i;
                    this.threads[threadIndex] = new Thread(new ThreadStart(AddMatrixNxN));
                    this.threads[threadIndex].Start();
                }
            }
           
        }

        private void AddMatrix(int row)
        {
            for (int i = 0; i < this.matrix.GetNoColumns(); i++)
            {
                int col = i;
                this.matrix.SetMatrixItem(row,
                                            col,
                                            this.matrix1.GetMatrixItem(row, col) +
                                            this.matrix2.GetMatrixItem(row, col));
            }
        }

        private void AddMatrixSeq()
        {
            for (int i = 0; i < this.matrix.GetNoRows(); i++)
                for (int j = 0; j < this.matrix.GetNoColumns(); j++)
                    this.matrix.SetMatrixItem(i,
                                              j,
                                              this.matrix1.GetMatrixItem(i, j) +
                                              this.matrix2.GetMatrixItem(i, j));
        }

        private void AddMatrixNxN()
        {
            Random random = new Random();
            int rowIndex = random.Next(this.matrix.GetNoRows());
            int colIndex = random.Next(this.matrix.GetNoColumns());
            mutex.WaitOne();

            while (!Check(rowIndex, colIndex))
            {
                rowIndex = random.Next(this.matrix.GetNoRows());
                colIndex = random.Next(this.matrix.GetNoColumns());
            }
            this.tuples.Add(new Tuple<int, int>(rowIndex, colIndex));
            this.matrix.SetMatrixItem(rowIndex,
                                      colIndex,
                                      this.matrix1.GetMatrixItem(rowIndex, colIndex) +
                                      this.matrix2.GetMatrixItem(rowIndex, colIndex));

            mutex.ReleaseMutex();
        }

        public override void SetNoThreads(int Code)
        {
            if (Code == 0)
                this.threads = new Thread[1];
            if (Code == 1)
                this.threads = new Thread[this.matrix.GetNoRows()];
            if (Code == 2)
                this.threads = new Thread[this.matrix.GetNoRows() * this.matrix.GetNoColumns()];
            InitThreads();
            Console.WriteLine(this.threads.Length);
        }
    }
}
