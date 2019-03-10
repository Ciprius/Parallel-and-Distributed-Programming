using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2.Model
{
    class MatrixMultiplication : MatrixOperations
    {
        public MatrixMultiplication(Matrix matrix1, Matrix matrix2)
        {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
            this.tuples = new List<Tuple<int, int>>();
            this.matrix = new Matrix(this.matrix1.GetNoRows(), this.matrix2.GetNoColumns());
        }
        public override void Add(){}
        public override void Mul(){}

        private void InitThreads()
        {
            if (this.threads.Length.Equals(1))
            {
                this.threads[0] = new Thread(new ThreadStart(MulMatrixSeq));
                this.threads[0].Start();
            }

            if (this.threads.Length.Equals(this.matrix.GetNoRows()))
            {
                for (int i = 0; i < threads.Length; i++)
                {
                    int threadIndex = i;
                    ThreadStart start = () => MulMatrix(threadIndex);
                    this.threads[threadIndex] = new Thread(start);
                    this.threads[threadIndex].Start();
                }
            }

            if (this.threads.Length.Equals(this.matrix.GetNoRows() * this.matrix.GetNoColumns()))
            {
                for (int i = 0; i < threads.Length; i++)
                {
                    int threadIndex = i;
                    this.threads[threadIndex] = new Thread(new ThreadStart(MulMatrixNxN));
                    this.threads[threadIndex].Start();
                }
            }
        }

        private void MulMatrix(int row)
        {
            for (int j = 0; j < this.matrix.GetNoColumns(); j++)
            { 
                int col1 = j;
                int sum = 0;
                for (int k = 0; k < this.matrix2.GetNoRows(); k++)
                {
                    int col2 = k;
                    sum = sum + this.matrix1.GetMatrixItem(row, col2) * this.matrix2.GetMatrixItem(col2, col1);
                }
                this.matrix.SetMatrixItem(row,
                                          col1,
                                          sum);
            }
        }

        private void MulMatrixSeq()
        { 
            for (int i = 0; i < this.matrix.GetNoRows(); i++)
            {
                for (int j = 0; j < this.matrix.GetNoColumns(); j++)
                {
                    int col1 = j;
                    int sum = 0;
                    for (int k = 0; k < this.matrix2.GetNoRows(); k++)
                    {
                        sum = sum + this.matrix1.GetMatrixItem(i, k) * this.matrix2.GetMatrixItem(k, col1);
                    }
                    this.matrix.SetMatrixItem(i,
                                              col1,
                                              sum);
                }
            }
        }

        private void MulMatrixNxN()
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
            int sum = 0;

            for (int k = 0; k < this.matrix1.GetNoColumns(); k++)
                sum = sum + this.matrix1.GetMatrixItem(rowIndex, k) * this.matrix2.GetMatrixItem(k, colIndex);

            this.matrix.SetMatrixItem(rowIndex, colIndex, sum);

            mutex.ReleaseMutex();
        }

        public override void SetNoThreads(int Code)
        {
            if (Code == 0)
                this.threads = new Thread[1];
            if (Code == 1)
                this.threads = new Thread[this.matrix.GetNoRows()];
            if (Code == 2)
                this.threads = new Thread[this.matrix.GetNoRows() * this.matrix.GetNoRows()];
            InitThreads();
            Console.WriteLine(this.threads.Length);
        }
    }
}
