using System;

namespace Steunijos.Web.Models
{
    public class GoogleDriveFileEntry
    {
        public string FileId { get; set; }
        public string FileName { get; set; }

        public long? FileSize { get; set; }

        public long? Version { get; set; }

        public DateTime? CreatedTime { get; set; }
    }
}