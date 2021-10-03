using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public interface IFileService
    {
        Task UploadFile(IFormFile file, string path);

        void DeleteFile(string path);


    }
}
