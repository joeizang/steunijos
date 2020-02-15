using Steunijos.Web.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Models
{
    public class PdfFiletype : FileTypeBase
    {
        public override AcceptedFileType FileExtension => AcceptedFileType.PDF;

        public int FileSize { get; private set; }

        public PdfFiletype(int fileSize)
        {
            ValidateFileSize(fileSize);
        }

    }
}
