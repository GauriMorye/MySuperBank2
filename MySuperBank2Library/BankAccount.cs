using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
namespace MySuperBank2Library
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (Transaction item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 1234567890;
        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of the deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);

        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of the withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("You don't have sufficient funds for the withdrawal");
            }
            var withdraw = new Transaction(-amount, date, note);
            allTransactions.Add(withdraw);

        }

        public void ShowTrasactions()
        {
            Console.WriteLine("DATE \t\t\t AMOUNT \t BALANCE \t\t DESCRIPTION  ");
            decimal balance = 0;
            foreach (var t in allTransactions)
            {
                balance += t.Amount;
                Console.WriteLine($"{t.Date}\t{t.Amount}\t\t{((int)balance)}\t\t\t{t.Notes}");
            }

        }
    }
}
