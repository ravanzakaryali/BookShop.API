namespace BookShop.Application.Asbtarcts.UnitOfWork;

public interface IUnitOfWork
{
    IAuthorAwardRepository AuthorAwardRepository { get; }
    IAuthorImageRepository AuthorImageRepository { get; }
    IAuthorRepository AuthorRepository { get; }
    IBookRepository BookRepository { get; }
    IReviewRepository ReviewRepository { get; }
    IBlogRepository BlogRepository { get; }
    IBookImageRepository BookImageRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IFormatRepository FormatRepository { get; }
    ITypeRepository TypeRepository { get; }
    ISubscribeRepository SubscribeRepository { get; }
    Task<int> SaveChangesAsync();
}
