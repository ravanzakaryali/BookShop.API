using Microsoft.AspNetCore.Http;
using Moq;

namespace BookShop.Application.Test.Services;

public class BaseService
{
    public static IFormFile GetFile(string fileName, string contentType, long length)
    {
        MemoryStream ms = new();
        StreamWriter writer = new(ms);
        writer.Flush();
        ms.Position = 0;
        Mock<IFormFile> _file = new();
        _file.Setup(f => f.OpenReadStream()).Returns(ms);
        _file.Setup(f => f.FileName).Returns(fileName);
        _file.Setup(f => f.Length).Returns(length);
        _file.Setup(f => f.ContentType).Returns(contentType);
        return _file.Object;
    }
}
