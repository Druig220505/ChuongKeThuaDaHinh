using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT01
{
    class Account
    {
        private double _balance;
        public Account()
        { }
        public Account(double balance)
        {
            this._balance = balance;
        }
        public double Balance
        {
            set { _balance = value; }
            get { return _balance; }
        }
        public virtual bool WithDraw(double amount)
        {
            return false;
        }
        public virtual bool Deposit(double amount)
        {
            return false;
        }
        public void PrintBalance()
        {
            Console.WriteLine("Balance:{0}", _balance);
        }
    }
    class SavingAccount : Account
    {
        private double _interesRate = 0.8;
        public SavingAccount() : base() {}
        public SavingAccount(double balance) : base(balance) {}
        public double InteresRate
        {
            set { _interesRate = value; }
            get { return _interesRate; }
        }
        public override bool WithDraw(double amount)
        {
            return false;
        }
        public override bool Deposit(double amount)
        {
            return false;
        }
    }
    class CheckingAccount : Account
    {
        public double InteresRate { get; private set; }

        public CheckingAccount() : base() {}
        public CheckingAccount(double balance) : base(balance) {}
        public override bool WithDraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance = Balance - (amount + amount * InteresRate);
                return true;
            }
            return false;

        }
        public override bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance = Balance + amount;
                return true;
            }
            return false;
        }
    }
    class ProgramBT01
    {
        static void Main(string[] args)
        {
            Account ac1 = new SavingAccount(200);
            Console.WriteLine("Saving Acc:");
            ac1.Deposit(100);
            ac1.PrintBalance();
            Account ac2 = new CheckingAccount(200);
            Console.WriteLine("Checking Acc:");
            ac2.WithDraw(50);
            ac2.PrintBalance();
            Console.ReadLine();
        }
    }
}
