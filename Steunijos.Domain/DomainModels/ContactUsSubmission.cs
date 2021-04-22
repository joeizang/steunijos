using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steunijos.Domain.Abstractions;

namespace Steunijos.Domain.DomainModels
{
    public class ContactUsSubmission : BaseDomainModel
    {
        [StringLength(200)]
        [Required]
        public string SendersFullName { get; set; }

        [StringLength(150)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string ReceivingEmailAddress { get; set; }

        public DateTimeOffset SubmissionDate { get; set; }

        [StringLength(150)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string SendersEmail { get; set; }

        [StringLength(1500)]
        public string MessageSent { get; set; }

        [StringLength(150)]
        public string MessageType { get; set; }

        [StringLength(200)]
        public string MessageSubject { get; set; }
    }
}
