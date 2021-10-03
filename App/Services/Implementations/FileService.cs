using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public class FileService : IFileService
    {
        IWebHostEnvironment _appEnvironment;

        public FileService(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public void DeleteFile(string path)
        {
            if (File.Exists(_appEnvironment.WebRootPath + path))
            {
                File.Delete(_appEnvironment.WebRootPath + path);
            }
        }

        public async Task UploadFile(IFormFile file, string path)
        {
            if (file != null)
            {
                DeleteFile(path);
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
        }
    }
}
