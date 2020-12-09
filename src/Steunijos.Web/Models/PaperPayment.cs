using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Steunijos.Web.Models
{
    public class PaperPayment
    {
        [StringLength(150)]
        public string PaperPaymentId { get; set; }

        //public List<PaperAuthor> Payer { get; set; }

        [StringLength(150)]
        public string TellerNumber { get; set; }

        public decimal AmountPaid { get; set; }

        [StringLength(150)]
        public string AuthorName { get; set; }

        public DateTimeOffset PaymentDate { get; set; }


    }
}