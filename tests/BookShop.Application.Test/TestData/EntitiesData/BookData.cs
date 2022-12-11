using BookShop.Application.CQRS.Commands.Request.BookRequest;
using BookShop.Application.DTOs;
using BookShop.Application.Test.Services;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.Test.TestData.EntitiesData;

public class BookData
{
    public static IEnumerable<BookCreateRequest[]> BookCreateRequests
    {
        get
        {
            yield return new BookCreateRequest[]
            {
                new BookCreateRequest()
                {
                    CategoryId = Guid.NewGuid().ToString(),
                    Description = "Revan",
                    Files = new FormFileCollection()
                    {
                        BaseService.GetFile("book.jpg","image/jpg",5123)
                    },
                    ImageMainTh = 1,
                    Name = "Book 1",
                    Price = 12,
                    TypeId = null,
                    VendorId = Guid.NewGuid().ToString()
                }
            };
            yield return new BookCreateRequest[]
           {
                new BookCreateRequest()
                {
                    CategoryId = Guid.NewGuid().ToString(),
                    Description = "Revan",
                    Files = new FormFileCollection()
                    {
                        BaseService.GetFile("book.jpg","image/jpg",500)
                    },
                    ImageMainTh = 1,
                    Name = new string('A',129),
                    Price = 12,
                    TypeId = null,
                    VendorId = Guid.NewGuid().ToString()
                }
           };
            yield return new BookCreateRequest[]
          {
                new BookCreateRequest()
                {
                    CategoryId = Guid.NewGuid().ToString(),
                    Description = "",
                    Files = new FormFileCollection()
                    {
                        BaseService.GetFile("book.jpg","image/jpg",500)
                    },
                    ImageMainTh = 1,
                    Name = new string('A',124),
                    Price = 12,
                    TypeId = null,
                    VendorId = Guid.NewGuid().ToString()
                }
          };
            yield return new BookCreateRequest[]
         {
                new BookCreateRequest()
                {
                    CategoryId = Guid.NewGuid().ToString(),
                    Description = "Revan",
                    Files = new FormFileCollection()
                    {
                        BaseService.GetFile("book.jpg","image/jpg",500)
                    },
                    ImageMainTh = 2,
                    Name = new string('A',124),
                    Price = 12,
                    TypeId = null,
                    VendorId = Guid.NewGuid().ToString()
                }
         };
        }
    }
    public static IEnumerable<BookUpdateRequest[]> BookUpdateRequests
    {
        get
        {
            yield return new BookUpdateRequest[]
            {
                new BookUpdateRequest("bookName",new UpdateBookDto
                    {
                        CategoryId = Guid.NewGuid().ToString(),
                        Description = "",
                        Name = "bookName2",
                        Price = -10,
                        TypeId = "",
                        VendorId = ""
                    })
            };
        }
    }
}
