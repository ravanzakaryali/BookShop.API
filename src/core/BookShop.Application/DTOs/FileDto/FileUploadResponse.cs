namespace BookShop.Application.DTOs.FileDto;

public class FileUploadResponse
{
    public string FileName { get; set; } = null!;
    public long Size { get; set; }
    public string ContainerName { get; set; } = null!;
}
