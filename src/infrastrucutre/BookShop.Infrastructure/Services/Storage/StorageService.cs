using BookShop.Application.Asbtarcts.Services.Storage;
using BookShop.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace BookShop.Infrastructure.Services.Storage;
public class StorageService : IStorageService
{
    readonly IStorage _storage;
    public StorageService(IStorage storage)
    {
        _storage = storage;
    }
    public string StorageName { get => _storage.GetType().Name; }

    public Task DeleteAsync(string containerName, string file) =>
        _storage.DeleteAsync(containerName, file);

    public List<string> GetFiles(string containerName) =>
        _storage.GetFiles(containerName);
    public bool HasFile(string containerName, string fileName) =>
        _storage.HasFile(containerName, fileName);

    public Task<List<FileUploadResponse>> UploadAsync(IFormFileCollection files, string containerName, string
         text = "image") =>
        _storage.UploadAsync(files, containerName, text);

    public Task<FileUploadResponse> UploadAsync(IFormFile file, string containerName = "files", string text = "image")
        => _storage.UploadAsync(file,containerName, text);
}
