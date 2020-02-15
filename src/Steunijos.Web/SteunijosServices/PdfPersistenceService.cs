using Steunijos.Web.Abstractions;
using Steunijos.Web.Data;
using Steunijos.Web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.JPMServices
{
    public class PdfPersistenceService : IPdfPersistenceService
    {
        private readonly SteunijosContext _db;

        public PdfPersistenceService(SteunijosContext db)
        {
            _db = db;
        }

        public Task PersistFileInDb()
        {
            throw new NotImplementedException();
        }

        public Task<IFilePersistenceService<PdfFiletype>> PersistFileInStorage()
        {
            throw new NotImplementedException();
        }

        public Task<IFilePersistenceService<PdfFiletype>> ValidateFileUpload(IFormFile upload)
        {
            throw new NotImplementedException();
        }
    }
}
