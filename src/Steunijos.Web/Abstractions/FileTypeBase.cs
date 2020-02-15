using Steunijos.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Abstractions
{
    public abstract class FileTypeBase : IFileType
    {
        public abstract AcceptedFileType FileExtension { get; }

        public int ValidateFileSize(int fileSize)
        {
            if (fileSize != int.MaxValue && fileSize != 0)
            {
                return fileSize;
            }

            throw new ArgumentOutOfRangeException($"{fileSize} is not a valid file size!");
        }
    }
}
