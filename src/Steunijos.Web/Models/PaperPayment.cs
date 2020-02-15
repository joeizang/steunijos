using System;
using System.Collections.Generic;

namespace Steunijos.Web.Models
{
    public class PaperPayment
    {
        public string PaperPaymentId { get; set; }

        //public List<PaperAuthor> Payer { get; set; }

        public string TellerNumber { get; set; }

        public decimal AmountPaid { get; set; }

        public string AuthorName { get; set; }

        public DateTimeOffset PaymentDate { get; set; }


    }
}