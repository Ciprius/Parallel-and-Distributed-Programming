using Lab1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private static Mutex mutex = new Mutex();
        private int max = 0;
        private Dictionary<int,BankAccount> bankAccounts = new Dictionary<int, BankAccount>();
        private Random random = new Random();
        private Stopwatch stopwatch;
        private Thread[] threads;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            ThreadListBox.Items.Clear();
            bankAccounts.Clear();
            this.max = 0;
            InitData();
            InitThread();
        }

        private void InitData()
        {
            int no = random.Next(5, 2000);
            AccountTextBox.Text = no.ToString();
            for (int i = 1 ; i <= no ; i ++)
            {
                BankAccount bank = new BankAccount(i, random.Next(10000));
                bankAccounts.Add(bank.GetID(), bank);
            }

            foreach (KeyValuePair<int, BankAccount> pair in bankAccounts)
                if (pair.Key > max)
                    max = pair.Key;
        }

        private void InitThread()
        {
            int no = random.Next(2, 100);
            ThreadTextBox.Text = no.ToString();
            this.threads = new Thread[no];
            for (int i = 0 ; i < this.threads.Length ; i ++)
            {
                threads[i] = new Thread(new ThreadStart(StartProg))
                {
                    Name = String.Format("Thread{0}", i + 1)
                };
                threads[i].Start();
            }
        }

        private void StartProg()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            BankAccount Faccount, Saccount;
            int FirstAccountId, SecondAccountId;

            FirstAccountId = random.Next(1, this.max);
            Faccount = bankAccounts[FirstAccountId];

            SecondAccountId = random.Next(1, this.max);
            while (SecondAccountId.Equals(FirstAccountId))
                SecondAccountId = random.Next(1, this.max);
            Saccount = bankAccounts[SecondAccountId];

            mutex.WaitOne();
            int Balance = random.Next(Faccount.GetBalance());
            Faccount.SetBalance(Faccount.GetBalance() - Balance);
            Faccount.AddOperation("-", Balance);

            Saccount.SetBalance(Saccount.GetBalance() + Balance);
            Saccount.AddOperation("+", Balance);
            if (random.Next(1, 3).Equals(1))
                Check();
            stopwatch.Stop();
            string name = Thread.CurrentThread.Name;
            this.Invoke((MethodInvoker)(() => ThreadListBox.Items.Add( name + ":")));
            this.Invoke((MethodInvoker)(() => ThreadListBox.Items.Add("Time :" + stopwatch.Elapsed.ToString())));
            this.Invoke((MethodInvoker)(() => ThreadListBox.Items.Add("Transfer " + Balance + " to account " + Faccount.GetID() + " -> " + Saccount.GetID())));
            this.Invoke((MethodInvoker)(() => ThreadListBox.Items.Add("After transfer :")));
            this.Invoke((MethodInvoker)(() => ThreadListBox.Items.Add("Account:" + Faccount.GetID() + " Balance:" + Faccount.GetBalance())));
            this.Invoke((MethodInvoker)(() => ThreadListBox.Items.Add("Account:" + Saccount.GetID() + " Balance:" + Saccount.GetBalance())));
            this.Invoke((MethodInvoker)(() => ThreadListBox.Items.Add("----------------------------")));
            mutex.ReleaseMutex();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Check();
        }

        private void Check()
        {
            int i = 1;
            foreach (KeyValuePair<int, BankAccount> pair in bankAccounts)
                if (pair.Value.CheckConsistency() == false)
                {
                    i = 0;
                    break;
                }
            if (i.Equals(1))
                MessageBox.Show("All good \n");
            else
                MessageBox.Show("Not good \n");
        }

        private void AccountLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
