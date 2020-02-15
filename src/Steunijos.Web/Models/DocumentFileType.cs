using Steunijos.Web.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Models
{
    public class DocumentFileType : FileTypeBase
    {
        public override AcceptedFileType FileExtension => AcceptedFileType.DOC_DOCX;

        public DocumentFileType(int fileSize)
        {
            ValidateFileSize(fileSize);
        }
    }
}
