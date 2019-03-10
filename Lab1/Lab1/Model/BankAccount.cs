using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    class BankAccount
    {
        private int Id;
        private int Balance;
        private int initBalance;
        private List<string> operations;

        public BankAccount(int Id, int Balance)
        {
            this.Id = Id;
            this.Balance = Balance;
            this.initBalance = this.Balance;
            this.operations = new List<string>();
        }

        public void AddOperation(string op, int amount)
        {
            string operation = op + " " + amount;
            this.operations.Add(operation);
        }

        public void SetBalance(int Balance) { this.Balance = Balance;  }
        public int  GetBalance() { return this.Balance; }
        public int  GetID() { return this.Id; }
        public string GetOperations()
        {
            string str = "";
            foreach (string op in this.operations)
                str = str + op + "\n";
            return str;
        }

        public bool CheckConsistency()
        {
            int initbal = this.initBalance;
            foreach (string st in this.operations)
            {
                string[] ops = st.Split(' ');
                if (ops[0].Equals("-"))
                    initbal = initbal - Int32.Parse(ops[1]);
                else
                    initbal = initbal + Int32.Parse(ops[1]);
            }
            if (this.Balance.Equals(initbal))
                return true;
            return false;
        }

        public override string ToString()
        {
            return "Account Id:" + this.Id +
                   " Balance: " + this.Balance;
        }

    }
}
