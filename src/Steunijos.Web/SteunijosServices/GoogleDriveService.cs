using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Steunijos.Web.Models;

namespace Steunijos.Web.SteunijosServices
{
    public interface IGoogleDriveService
    {
        ClientSecrets ClientSecrets { get; set; }
        UserCredential UserCred { get; }
        DriveService GDriveService { get; }
    }

    public class GoogleDriveService : IGoogleDriveService
    {
        private readonly IConfiguration _config;
        private readonly IHostEnvironment _env;

        public ClientSecrets ClientSecrets { get; set; } = new ClientSecrets();

        private string[] scopes = new string[]{
            DriveService.Scope.Drive,
            DriveService.Scope.DriveFile
        };

        public UserCredential UserCred { get; private set; }
        public DriveService GDriveService { get; private set; }

        public GoogleDriveService(IConfiguration config, IHostEnvironment env)
        {
            _config = config;
            _env = env;
            ClientSecrets.ClientId = _config.GetValue<string>("AuthGoogle:clientId");
            ClientSecrets.ClientSecret = _config.GetValue<string>("AuthGoogle:clientSecret");
            UserCred = ConnectToGoogleDrive(_env).Result;
            GDriveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = UserCred,
                ApplicationName = "steunijos"
            });
        }
        private async Task<UserCredential> ConnectToGoogleDrive(IHostEnvironment env)
        {
            UserCredential result;
            using (var fStream = new FileStream($"{env.ContentRootPath}clientGoogle.json",
                            FileMode.Open, FileAccess.Read))
            {
                var folderPath = env.ContentRootPath;
                var filePath = Path.Combine(folderPath, "clientGoogleSecret.json");
                result = await GoogleWebAuthorizationBroker
                            .AuthorizeAsync(ClientSecrets, scopes,
                            "steunijos2020@gmail.com",
                            CancellationToken.None, new FileDataStore(filePath, true))
                            .ConfigureAwait(false);
            }
            return result;
        }

        public List<GoogleDriveFileEntry> GetDriveFiles()
        {
            var fileListRequest = GDriveService.Files.List();

            fileListRequest.PageSize = 25;
            fileListRequest.Fields = "nextPageToken, files(id, name)";

            var files = fileListRequest.Execute().Files;

            List<GoogleDriveFileEntry> results = new List<GoogleDriveFileEntry>();

            if (!(files is null) && files.Count > 0)
            {
                results = files.Select(f => new GoogleDriveFileEntry
                {
                    CreatedTime = f.CreatedTime,
                    FileId = f.Id,
                    FileName = f.Name,
                    FileSize = f.Size,
                    Version = f.Version
                }).ToList();
            }
            return results;
        }

        public async Task UploadToGDriveAsync(IFormFile file)
        {
            try
            {
                var dir = $"{_env.ContentRootPath}";
                var combinedPath = Path.Combine(dir, file.FileName);

                using (var fstream = new FileStream(combinedPath,
                    FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fstream);
                }

            }
            catch
            {

            }
        }
    }
}