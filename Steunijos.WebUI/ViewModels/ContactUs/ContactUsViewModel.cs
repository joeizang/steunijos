using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.WebUI.ViewModels.ContactUs
{
    public class ContactUsViewModel
    {
        public string FullName { get; set; }

        public string SubmissionId { get; set; }

        public string SubmittedMessage { get; set; }

        public string EmailAddress { get; set; }

        public DateTimeOffset SubmissionDate { get; set; }

        public string MessageType { get; set; }
    }
}
