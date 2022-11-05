using BookShop.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.Asbtarcts.Services.Storage
{
    public interface IStorage
    {
        Task<List<FileUploadResponse>> UploadAsync(IFormFileCollection files, string containerName = "files", string text = "image");
        Task<FileUploadResponse> UploadAsync(IFormFile file, string containerName = "files", string text = "image");
        Task DeleteAsync(string containerName, string fileName);
        List<string> GetFiles(string containerName);
        bool HasFile(string containerName, string fileName);
    }
}
