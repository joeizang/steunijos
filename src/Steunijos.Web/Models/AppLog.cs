using System;

namespace Steunijos.Web.Models
{
    public class AppLog
    {
        public string AppLogId { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string ExceptionDetails { get; set; }

        public DateTimeOffset HappenedAt { get; set; }

        public bool AnyLoggedInUser { get; set; }

        public string InnerException { get; set; }
    }
}