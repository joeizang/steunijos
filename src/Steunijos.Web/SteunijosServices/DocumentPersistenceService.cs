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
    public class DocumentPersistenceService : IDocumentPersistenceService
    {
            //1. read all the metadata from file uploaded and create a Paper object to be
            //   be persisted in the database for later use.
            //2. save the uploaded file on the filesystem somewhere outside the application folder
            //3. validate form uploads to make sure that the file meets some acceptable criteria

        private readonly SteunijosContext _db;

        public DocumentPersistenceService(SteunijosContext db)
        {
            _db = db;
        }

        public Task PersistFileInDb()
        {
            throw new NotImplementedException();
        }

        public Task<IFilePersistenceService<DocumentFileType>> PersistFileInStorage()
        {
            throw new NotImplementedException();
        }

        public Task<IFilePersistenceService<DocumentFileType>> ValidateFileUpload(IFormFile upload)
        {
            throw new NotImplementedException();
        }
    }
}
