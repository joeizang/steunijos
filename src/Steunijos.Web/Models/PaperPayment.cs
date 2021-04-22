using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Steunijos.Web.Models
{
    public class PaperPayment
    {
        [StringLength(150)]
        [Key]
        public string PaperPaymentId { get; set; } = Guid.NewGuid().ToString("D");

        //public List<PaperAuthor> Payer { get; set; }

        [StringLength(150)]
        public string TellerNumber { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal AmountPaid { get; set; }

        [StringLength(150)]
        public string AuthorName { get; set; }

        public DateTimeOffset? PaymentDate { get; set; }

        public DateTimeOffset CreatedAt { get; set; }


    }
}