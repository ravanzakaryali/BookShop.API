using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using Microsoft.AspNetCore.Http;
using Moq;
using System.IO;

namespace BookShop.Application.Test.TestData.EntitiesData;

public class AuhtorData
{
    private static Mock<IFormFile> _file;
    static AuhtorData()
    {
        _file = new Mock<IFormFile>();
        var fileName = "test.pdf";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Flush();

        ms.Position = 0;
        _file.Setup(f => f.OpenReadStream()).Returns(ms);
        _file.Setup(f => f.FileName).Returns(fileName);
        _file.Setup(f => f.Length).Returns(510);
        _file.Setup(f => f.ContentType).Returns("image/jpg");
    }
    public static IEnumerable<AuthorCreateRequest?[]> AuthorCreateRequest
    {
        get
        {
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest(new string('A',65),new string('A',43),_file.Object),
            };
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest(new string('A',43),new string('A',15),_file.Object),
            };
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest(new string('A',43),new string('A',257),_file.Object),
            };
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest("",new string('A',64),_file.Object),
            };
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest(" ",new string('A',64),_file.Object)
            };
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest(new string('A',43),"",_file.Object)
            };
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest(new string('A',43)," ",_file.Object)
            };
        }
    }
}
