using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TransactionLog
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } // Credit/Debit
        public DateTime Date { get; set; }

    }
}
