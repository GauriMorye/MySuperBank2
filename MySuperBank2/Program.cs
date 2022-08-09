using MySuperBank2Library;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank2
{
    class Program
    {
        static void Main(string[] args)
        {

            var myacc = new BankAccount("Gauri", 1000);
            //Console.WriteLine($"Account {myacc.Number} was created for {myacc.Owner} with balance Rs{myacc.Balance}");

            myacc.MakeWithdrawal(120, DateTime.Now, "Food");

            myacc.MakeWithdrawal(45, DateTime.Now, "Travel");

            myacc.MakeDeposit(500, DateTime.Now, "PocketMoney");

            try
            {
                BankAccount myacc2 = new BankAccount("Gauri", -90);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("An exception occured");
                Console.WriteLine(e.Message);
            }

            try
            {
                myacc.MakeWithdrawal(2000, DateTime.Now, "Watch");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("A exception occured");
                Console.WriteLine(e.Message);
            }

            myacc.ShowTrasactions();
        }
    }
}
