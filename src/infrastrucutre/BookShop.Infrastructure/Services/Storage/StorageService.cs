using BookShop.Application.Asbtarcts.Services.Storage;
using BookShop.Application.DTOs.FileDto;
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
         username = "") =>
        _storage.UploadAsync(files, containerName, username);
}
