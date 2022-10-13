using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository;
using BookShop.Application.Asbtarcts.Repository.Base;
using BookShop.Application.Contracts.Repository.Base;
using BookShop.Domain.Entities;

namespace BookShop.Application.Contracts.Repository;

public class BookRepository : Repository<IApplicationDbContext, Book, string>, IBookRepository
{
    public BookRepository(IApplicationDbContext context) : base(context)
    {
    }
}
