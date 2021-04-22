using System;
using System.ComponentModel.DataAnnotations;

namespace Steunijos.Web.Models
{
    public class ContactUsSubmission
    {
        [Key] [StringLength(200)]
        public string SubmissionId { get; set; } = Guid.NewGuid().ToString("D");

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