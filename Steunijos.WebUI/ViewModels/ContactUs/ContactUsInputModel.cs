using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Steunijos.Domain.DomainModels;

namespace Steunijos.WebUI.ViewModels.ContactUs
{
    public class ContactUsInputModel
    {

        public ContactUsInputModel()
        {
            MessageId = Guid.NewGuid().ToString();
        }
        [Required]
        [EnumDataType(typeof(MessageType))]
        public MessageType MessageType { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(400)]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Required()]
        [DataType(DataType.Text)]
        public string MessageId { get; set; }
    }
}
