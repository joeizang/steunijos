using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Abstractions
{
    public interface IFilePersistenceService<IFileType>
    {
        Task<IFilePersistenceService<IFileType>> ValidateFileUpload(IFormFile upload);

        Task PersistFileInDb();

        Task<IFilePersistenceService<IFileType>> PersistFileInStorage();
    }
}
