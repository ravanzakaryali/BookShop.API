using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BookShop.Application.Asbtarcts.Services.Storage.Azure;
using BookShop.Application.DTOs.FileDto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BookShop.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : StorageHelper, IAzureStorage
    {
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;
        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration.GetConnectionString("Azure"));
        }

        public async Task DeleteAsync(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string containerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
        }

        public bool HasFile(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
        }

        public async Task<List<FileUploadResponse>> UploadAsync(IFormFileCollection files, string containerName = "files", string username = "username")
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<FileUploadResponse> response = new();
            foreach (var file in files)
            {
                string fileNewName = FileRename(file.FileName, username, containerName, HasFile);
                BlobClient blobClient = _blobContainerClient.GetBlobClient(fileNewName);
                await blobClient.UploadAsync(file.OpenReadStream());
                response.Add(new FileUploadResponse
                {
                    ContainerName = containerName,
                    FileName = fileNewName,
                });
            }
            return response;
        }
    }
}
