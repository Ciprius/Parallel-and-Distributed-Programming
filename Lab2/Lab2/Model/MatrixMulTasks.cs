using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Model
{
    class MatrixMulTasks : MatrixOperations
    {
        private Task[] task;

        public MatrixMulTasks(Matrix matrix1, Matrix matrix2)
        {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
            this.matrix = new Matrix(this.matrix1.GetNoRows(), this.matrix1.GetNoColumns());
        }
        public override void Add(){}

        public override void Mul()
        {
            if (task.Length.Equals(1))
                MulMat();
            if (task.Length.Equals(this.matrix.GetNoRows()))
                MulMatN();
            if (task.Length.Equals(this.matrix.GetNoRows() * this.matrix.GetNoColumns()))
                MulMatNxN();
        }

        private void MulMat()
        {
            task[0] = Task.Factory.StartNew(() =>{
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
            });
            Task.WaitAll(task);
        }

        private void MulMatN()
        {
            for (int i = 0; i < this.matrix.GetNoRows(); i++)
            {
                int row = i;
                task[i] = Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < this.matrix.GetNoColumns(); j++)
                    {
                        int col1 = j, sum = 0;
                        for (int k = 0; k < this.matrix2.GetNoRows(); k++)
                        {
                            int col2 = k;
                            sum = sum + this.matrix1.GetMatrixItem(row, col2) * this.matrix2.GetMatrixItem(col2, col1);
                        }
                        this.matrix.SetMatrixItem(row,
                          col1,
                          sum);
                    }
                });
            }
            Task.WaitAll(task);
        }

        private void MulMatNxN()
        {
            int t = 0;
            for (int i = 0; i < this.matrix.GetNoRows(); i++)
            {
                int row = i;
                for (int j = 0; j < this.matrix.GetNoColumns(); j++)
                { 
                        int col1 = j, sum = 0;
                    task[t] = Task.Factory.StartNew(() =>
                    {
                        for (int k = 0; k < this.matrix2.GetNoRows(); k++)
                        {
                            int col2 = k;
                            sum = sum + this.matrix1.GetMatrixItem(row, col2) * this.matrix2.GetMatrixItem(col2, col1);
                        }
                        this.matrix.SetMatrixItem(row,
                          col1,
                          sum);
                    });
                    t++;
                }
            }
            Task.WaitAll(task);
        }

        public override void SetNoThreads(int Code)
        {
            if (Code == 0)
                this.task = new Task[1];
            if (Code == 1)
                this.task = new Task[this.matrix.GetNoRows()];
            if (Code == 2)
                this.task = new Task[this.matrix.GetNoRows() * this.matrix.GetNoColumns()];
            Console.WriteLine(this.task.Length);
        }
    }
}
