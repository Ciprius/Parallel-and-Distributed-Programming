using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2.Model
{
    class MatrixAddThreadPool : MatrixOperations
    {
        public MatrixAddThreadPool(Matrix matrix1, Matrix matrix2)
        {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
            matrix = new Matrix(matrix1.GetNoRows(),matrix2.GetNoColumns());
        }
        public override void Mul(){}

        public override void Add()
        {
            if (this.size.Equals(1))
                ThreadPool.QueueUserWorkItem(new WaitCallback(ComputeSeq), 1);
            if (this.size.Equals(this.matrix.GetNoRows()))
                AddMatN();
            if (this.size.Equals(this.matrix.GetNoRows()*this.matrix.GetNoColumns()))
                AddMatNxN();
        }

        private void AddMatNxN()
        {
            for (int i = 0; i < this.matrix.GetNoRows(); i++)
                for (int j = 0; j < this.matrix.GetNoColumns(); j++)
                {
                    var tuple = new Tuple<int, int>(i,j);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ComputeNxN),tuple);
                }
        }

        private void ComputeNxN(object tuple)
        {
            var tup = (Tuple<int, int>)tuple;
            this.matrix.SetMatrixItem(tup.Item1, tup.Item2,this.matrix1.GetMatrixItem(tup.Item1, tup.Item2) +
                                                           this.matrix2.GetMatrixItem(tup.Item1, tup.Item2));
        }

        private void AddMatN()
        {
            for (int i = 0; i < this.matrix.GetNoRows(); i++)
            {
                int row = i;
                ThreadPool.QueueUserWorkItem(new WaitCallback(ComputeN), row);
            }
        }

        private void ComputeN(object row)
        {
            int ro = Convert.ToInt32(row);
            for (int j = 0; j < this.matrix.GetNoColumns(); j++)
                this.matrix.SetMatrixItem(ro, j, this.matrix1.GetMatrixItem(ro, j) +
                                                           this.matrix2.GetMatrixItem(ro, j));
        }

        private void ComputeSeq(object obj)
        {
            for (int i = 0; i < this.matrix.GetNoRows(); i++)
                for (int j = 0; j < this.matrix.GetNoColumns(); j++)
                    this.matrix.SetMatrixItem(i, j, this.matrix1.GetMatrixItem(i, j) +
                                                           this.matrix2.GetMatrixItem(i, j));
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
                this.size = matrix.GetNoRows() * matrix.GetNoColumns();
                ThreadPool.SetMaxThreads(matrix.GetNoRows() * matrix.GetNoColumns(), matrix.GetNoRows() * matrix.GetNoColumns());
            }
        }
    }
}
