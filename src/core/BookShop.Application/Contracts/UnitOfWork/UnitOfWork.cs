using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.Contracts.Repository;

namespace BookShop.Application.Contracts.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _dbContext;
    public UnitOfWork(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private IBookRepository? _bookRepository;
    private IReviewRepository? _reviewRepository;
    private IBlogRepository? _blogRepository;
    public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_dbContext);
    public IReviewRepository ReviewRepository => _reviewRepository ??= new ReviewRepository(_dbContext);
    public IBlogRepository BlogRepository => _blogRepository ??= new BlogRepository(_dbContext);

    public IAuthorAwardRepository AuthorAwardRepository => throw new NotImplementedException();

    public IAuthorImageRepository AuthorImageRepository => throw new NotImplementedException();

    public IAuthorRepository AuthorRepository => throw new NotImplementedException();

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
