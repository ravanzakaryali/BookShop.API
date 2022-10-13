using BookShop.Application.Asbtarcts.Repository;

namespace BookShop.Application.Asbtarcts.UnitOfWork;

public interface IUnitOfWork
{
    IAuthorAwardRepository AuthorAwardRepository { get; }
    IAuthorImageRepository AuthorImageRepository { get; }
    IAuthorRepository AuthorRepository { get; }
    IBookRepository BookRepository { get; }
    IReviewRepository ReviewRepository { get; }
    IBlogRepository BlogRepository { get; }
    Task<int> SaveChangesAsync();
}
