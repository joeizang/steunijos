using Steunijos.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Abstractions
{
    public interface IFileType
    {
        AcceptedFileType FileExtension { get; }

        int ValidateFileSize(int fileSize);
    }
}
