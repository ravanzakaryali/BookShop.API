using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using BookShop.Application.DTOs.AuthorDtos;
using BookShop.Application.Test.Services;

namespace BookShop.Application.Test.TestData.EntitiesData;

public class AuhtorData
{
    public static IEnumerable<AuthorCreateRequest?[]> AuthorCreateRequest
    {
        get
        {
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest(new string('A',65),new string('A',43),BaseService.GetFile("test.jpg","image/jpg",510))
            };
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest(new string('A',43),new string('A',15),BaseService.GetFile("test.jpg","image/jpg",510))
            };
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest(new string('A',43),new string('A',257),BaseService.GetFile("test.jpg","image/jpg",510))
            };
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest("",new string('A',64),BaseService.GetFile("test.jpg","application/pdf",6000)),
            };
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest(" ",new string('A',64),BaseService.GetFile("test.jpg","image/jpg",510))
            };
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest(new string('A',43),"",BaseService.GetFile("test.pdf","application/pdf",5121))
            };
            yield return new AuthorCreateRequest[]
            {
                new AuthorCreateRequest(new string('A',43)," ",BaseService.GetFile("test.jpg","image/jpg",510))
            };
        }
    }
    public static IEnumerable<AuthorUpdateRequest[]> AuthorUpdateRequest
    {
        get
        {
            yield return new AuthorUpdateRequest[]
            {
                new AuthorUpdateRequest(Guid.NewGuid().ToString(),new AuthorCommandDto
                {
                    Name = new string('A',65),
                    Description = new string('A',43)
                })
            };
        }
    }
    public static IEnumerable<AuthorImageUpdateRequest[]> AuthorImageUpdateRequest
    {
        get
        {
            yield return new AuthorImageUpdateRequest[]
            {
                new AuthorImageUpdateRequest(Guid.NewGuid().ToString(),Guid.NewGuid().ToString(),BaseService.GetFile("test.jpg","image/jpg",6000))
            };
            yield return new AuthorImageUpdateRequest[]
            {
                new AuthorImageUpdateRequest(Guid.NewGuid().ToString(),Guid.NewGuid().ToString(),BaseService.GetFile("test.pdf","application/pdf",510))
            };
        }
    }
}
