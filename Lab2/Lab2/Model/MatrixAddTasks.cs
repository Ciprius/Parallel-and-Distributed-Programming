using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Model
{
    class MatrixAddTasks : MatrixOperations
    {
        private Task[] task;

        public MatrixAddTasks(Matrix matrix1, Matrix matrix2)
        {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
            this.matrix = new Matrix(this.matrix1.GetNoRows(), this.matrix1.GetNoColumns());
        }
        public override void Mul(){}

        public override void Add()
        {
            if (task.Length.Equals(1))
                AddMat();
            if (task.Length.Equals(this.matrix.GetNoRows()))
                AddMatN();
            if (task.Length.Equals(this.matrix.GetNoRows() * this.matrix.GetNoColumns()))
                AddMatNxN();
        }

        private void AddMat()
        {
            task[0] = Task.Factory.StartNew( () => {
                for (int i = 0; i < this.matrix.GetNoRows(); i++)
                {
                    int row = i;
                    for (int j = 0; j < this.matrix.GetNoColumns(); j++)
                    {
                        int col = j;
                        this.matrix.SetMatrixItem(row, col, this.matrix1.GetMatrixItem(row, col) +
                                                        this.matrix2.GetMatrixItem(row, col));
                    }
                }
            });
            Task.WaitAll(task);
        }

        private void AddMatN()
        {
            for (int i = 0; i < this.matrix.GetNoRows(); i++)
            {
                int row = i;
                task[i] = Task.Factory.StartNew(() => {
                    for (int j = 0; j < this.matrix.GetNoColumns(); j++)
                    {
                        int col = j;
                        this.matrix.SetMatrixItem(row, col, this.matrix1.GetMatrixItem(row, col) +
                                                        this.matrix2.GetMatrixItem(row, col));
                    }
                });
            }
            Task.WaitAll(task);
        }
        
        private void AddMatNxN()
        {
            int k = 0;
            for (int i = 0; i < this.matrix.GetNoRows(); i++)
            {
                int row = i;
                for (int j = 0; j < this.matrix.GetNoColumns(); j++)
                {
                    int col = j;
                    task[k] = Task.Factory.StartNew(() => {
                        this.matrix.SetMatrixItem(row, col, this.matrix1.GetMatrixItem(row, col) +
                                                        this.matrix2.GetMatrixItem(row, col));
                    });
                    k++;
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
