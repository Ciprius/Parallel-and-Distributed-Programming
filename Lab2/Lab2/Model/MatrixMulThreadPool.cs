using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2.Model
{
    class MatrixMulThreadPool : MatrixOperations
    {
        public MatrixMulThreadPool(Matrix matrix1, Matrix matrix2)
        {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
            this.matrix = new Matrix(matrix1.GetNoRows(), matrix1.GetNoColumns());
        }
        public override void Add(){}
        public override void Mul()
        {
            if (this.size.Equals(1))
                ThreadPool.QueueUserWorkItem(new WaitCallback(ComputeSeq), 1);
            if (this.size.Equals(this.matrix.GetNoRows()))
                MulMatN();
            if (this.size.Equals(this.matrix.GetNoRows() * this.matrix.GetNoColumns()))
                MulMatNxN();
        }

        private void MulMatNxN()
        {
            for( int i = 0; i<this.matrix.GetNoRows(); i++ )
                for (int j = 0; j < this.matrix.GetNoColumns(); j++)
                {
                    var tuple = new Tuple<int, int>(i, j);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ComputeNxN), tuple);
                }
        }

        private void ComputeNxN(object tuple)
        {
            var tup = (Tuple<int,int>)tuple;
            int sum = 0;
            for (int k = 0; k < this.matrix2.GetNoRows(); k++)
                sum = sum + this.matrix1.GetMatrixItem(tup.Item1, k) * this.matrix2.GetMatrixItem(k, tup.Item2);
            this.matrix.SetMatrixItem(tup.Item1, tup.Item2, sum);
        }

        private void MulMatN()
        {
            for (int i = 0; i < this.matrix.GetNoRows(); i++)
            {
                int row = i;
                ThreadPool.QueueUserWorkItem(new WaitCallback(ComputeN), row);
            }
        }

        private void ComputeN(object obj)
        {
            int row = Convert.ToInt32(obj);
            for (int j = 0; j < this.matrix.GetNoColumns(); j++)
            {
                int sum = 0;
                for (int k = 0; k < this.matrix2.GetNoRows(); k++)
                    sum = sum + this.matrix1.GetMatrixItem(row, k) * this.matrix2.GetMatrixItem(k, j);
                this.matrix.SetMatrixItem(row, j, sum);
            }
        }

        private void ComputeSeq(object obj)
        {
            for (int i = 0; i < this.matrix.GetNoRows(); i++)
            {
                int row = i;
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
        }

        public override void SetNoThreads(int Code)
        {
            if (Code == 0)
            {
                this.size = 1;
                ThreadPool.SetMaxThreads(1, 1);
            }
            if (Code == 1)
            {
                this.size = matrix.GetNoColumns();
                ThreadPool.SetMaxThreads(matrix.GetNoColumns(), matrix.GetNoColumns());
            }
            if (Code == 2)
            {
                this.size = matrix.GetNoColumns() * matrix.GetNoColumns();
                ThreadPool.SetMaxThreads(matrix.GetNoColumns() * matrix.GetNoColumns(), matrix.GetNoColumns() * matrix.GetNoColumns());
            }
        }
    }
}
