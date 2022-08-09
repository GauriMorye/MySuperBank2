using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
namespace MySuperBank2Library
{
    public class Transaction
    {
        public decimal Amount { get; }
        public string AmountInWords { 
            get
            {
                return ((int)(Amount)).ToWords();
            } 
        }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string notes)
        {
            Amount = amount;
            Date = date;
            Notes = notes;
        }
    }
}
