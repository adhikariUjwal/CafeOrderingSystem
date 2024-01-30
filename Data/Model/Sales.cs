using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Data.Model
{
    public class Sales
    {
        public Guid SalesId { get; set; }= Guid.NewGuid();

        public Coffee Coffee { get; set; }

        public string Quantity { get; set; }    
        public string PaidBy { get; set; }

        public  List<Add_ins> Addins { get; set; }
        public DateTime TransactionDate { get; set; }

        public string TotalAmount { get; set; }

        public string DiscountAmount { get; set; }

        public string TransactionAmount { get; set; }


    }
}
