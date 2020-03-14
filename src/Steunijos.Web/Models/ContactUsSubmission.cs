using System;

namespace Steunijos.Web.Models
{
    public class ContactUsSubmission
    {
        public string SubmissionId { get; set; }

        public string SendersFullName { get; set; }

        public string ReceivingEmailAddress { get; set; }

        public DateTimeOffset SubmissionDate { get; set; }

        public string SendersEmail { get; set; }

        public string MessageSent { get; set; }

        public string MessageType { get; set; }

        public string MessageSubject { get; set; }
    }
}