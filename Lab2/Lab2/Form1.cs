using Lab2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private Matrix matrix1;
        private Matrix matrix2;
        private MatrixOperations matrixAddition;
        private MatrixOperations matrixMultiplication;
        private MatrixOperations matrixAddThreadPool;
        private MatrixOperations matrixMulThreadPool;
        private MatrixOperations matrixAddTasks;
        private MatrixOperations matrixMulTasks;

        public Form1()
        {
            InitializeComponent();
            Init();
            ThreadRadioBtnn.Checked = true;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            matrixAddition = new MatrixAddition(matrix2.GetNoColumns(), matrix1, matrix2);
            CheckThreads();
            Matrix matrix = matrixAddition.GetMatrix();
            foreach (Thread thread in matrixAddition.GetThreads())
                thread.Join();
            stopWatch.Stop();
            DisplayMatrix(matrix, AddtionPanel);
            TimeBox.Text = stopWatch.Elapsed.ToString();
        }
        
        private void DisplayMatrix(Matrix matrix, Panel MatrixPanel)
        {
            Button[,] labels = new Button[matrix.GetNoRows(), matrix.GetNoColumns()];
            MatrixPanel.Controls.Clear();
            for (int i = 0; i < matrix.GetNoRows(); i++)
            {
                for (int j = 0; j < matrix.GetNoColumns(); j++)
                {
                    labels[i, j] = new Button()
                    {
                        Width = 40,
                        Height = 20,
                        Text = matrix.GetMatrixItem(i, j).ToString(),
                        Location = new Point(j*37 + 10, i*17 + 10),
                        Parent = MatrixPanel,
                    };
                } 
            }
        }

        private void InitMatrix()
        {
            Random random = new Random();
            for (int i = 0; i < matrix1.GetNoRows(); i++)
                for (int j = 0; j < matrix1.GetNoColumns(); j++)
                    matrix1.SetMatrixItem(i, j, random.Next(1,10));
            
            for (int i = 0; i < matrix2.GetNoRows(); i++)
                for (int j = 0; j < matrix2.GetNoColumns(); j++)
                    matrix2.SetMatrixItem(i, j, random.Next(1,10));
        }

        private void MulButton_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            matrixMultiplication = new MatrixMultiplication(matrix1, matrix2);
            CheckThreads();
            Matrix matrix = matrixMultiplication.GetMatrix();
            foreach (Thread thread in matrixMultiplication.GetThreads())
                thread.Join();
            stopWatch.Stop();
            DisplayMatrix(matrix, MulPanel);
            TimeBox1.Text = stopWatch.Elapsed.ToString();
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            Random rnd = new Random();
            int size = rnd.Next(1, 5);
            matrix1 = new Matrix(size, size);
            matrix2 = new Matrix(size, size);
            InitMatrix();
            DisplayMatrix(matrix1, MatrixPanelMul1);
            DisplayMatrix(matrix2, MatrixPanelMul2);
            DisplayMatrix(matrix1, MatrixPanel1);
            DisplayMatrix(matrix2, MatrixPanel2);
            MulPanel.Controls.Clear();
            AddtionPanel.Controls.Clear();
        }

        private void CheckThreads()
        {
            if (ThreadRadioBtn1.Checked == true)
            {
                if (this.matrixAddition != null)
                    this.matrixAddition.SetNoThreads(0);
                if (this.matrixMultiplication != null)
                    this.matrixMultiplication.SetNoThreads(0);
                if (this.matrixAddThreadPool != null)
                    this.matrixAddThreadPool.SetNoThreads(0);
                if (this.matrixMulThreadPool != null)
                    this.matrixMulThreadPool.SetNoThreads(0);
                if (this.matrixAddTasks != null)
                    this.matrixAddTasks.SetNoThreads(0);
                if (this.matrixMulTasks != null)
                    this.matrixMulTasks.SetNoThreads(0);
            }
            if (ThreadRadioBtnn.Checked == true)
            {
                if (this.matrixAddition != null)
                    this.matrixAddition.SetNoThreads(1);
                if (this.matrixMultiplication != null)
                    this.matrixMultiplication.SetNoThreads(1);
                if (this.matrixAddThreadPool != null)
                    this.matrixAddThreadPool.SetNoThreads(1);
                if (this.matrixMulThreadPool != null)
                    this.matrixMulThreadPool.SetNoThreads(1);
                if (this.matrixAddTasks != null)
                    this.matrixAddTasks.SetNoThreads(1);
                if (this.matrixMulTasks != null)
                    this.matrixMulTasks.SetNoThreads(1);
            }
            if (ThreadRadioBtnnXn.Checked == true)
            {
                if (this.matrixAddition != null)
                    this.matrixAddition.SetNoThreads(2);
                if (this.matrixMultiplication != null)
                    this.matrixMultiplication.SetNoThreads(2);
                if (this.matrixAddThreadPool != null)
                    this.matrixAddThreadPool.SetNoThreads(2);
                if (this.matrixMulThreadPool != null)
                    this.matrixMulThreadPool.SetNoThreads(2);
                if (this.matrixAddTasks != null)
                    this.matrixAddTasks.SetNoThreads(2);
                if (this.matrixMulTasks != null)
                    this.matrixMulTasks.SetNoThreads(2);
            }
        }

        private void AddThPoolBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            matrixAddThreadPool = new MatrixAddThreadPool(matrix1, matrix2);
            CheckThreads();
            matrixAddThreadPool.Add();
            Matrix matrix = matrixAddThreadPool.GetMatrix();
            stopwatch.Stop();
            DisplayMatrix(matrix, AddtionPanel);
            TimeBox.Text = stopwatch.Elapsed.ToString();
        }

        private void MulThPoolBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            matrixMulThreadPool = new MatrixMulThreadPool(matrix1, matrix2);
            CheckThreads();
            matrixMulThreadPool.Mul();
            Matrix matrix = matrixMulThreadPool.GetMatrix();
            stopwatch.Stop();
            DisplayMatrix(matrix, MulPanel);
            TimeBox1.Text = stopwatch.Elapsed.ToString();
        }

        private void AddTaskBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            matrixAddTasks = new MatrixAddTasks(matrix1, matrix2);
            CheckThreads();
            matrixAddTasks.Add();
            Matrix matrix = matrixAddTasks.GetMatrix();
            stopwatch.Stop();
            DisplayMatrix(matrix, AddtionPanel);
            TimeBox.Text = stopwatch.Elapsed.ToString();
        }

        private void MulTaskBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            matrixMulTasks = new MatrixMulTasks(matrix1, matrix2);
            CheckThreads();
            matrixMulTasks.Mul();
            Matrix matrix = matrixMulTasks.GetMatrix();
            stopwatch.Stop();
            DisplayMatrix(matrix, MulPanel);
            TimeBox1.Text = stopwatch.Elapsed.ToString();
        }
    }
}
