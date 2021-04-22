using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steunijos.Domain.Abstractions;

namespace Steunijos.Domain.DomainModels
{
    public class PaperPayment : BaseDomainModel
    {
        [StringLength(150)]
        public string TellerNumber { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal AmountPaid { get; set; }

        [StringLength(150)]
        public string AuthorName { get; set; }

        public DateTimeOffset? PaymentDate { get; set; }
    }
}
