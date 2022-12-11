using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Infrastructure.Contracts.Repository;
using BookShop.Persistence.Data;

namespace BookShop.Infrastructure.Contracts.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private IBookRepository? _bookRepository;
    private IReviewRepository? _reviewRepository;
    private IBlogRepository? _blogRepository;
    private IBookImageRepository? _bookImageRepository;
    private ICategoryRepository? _categoryRepository;
    private IFormatRepository? _formatRepository;
    private ITypeRepository? _typeRepository;
    private IAuthorRepository? _authorRepository;
    private ISubscribeRepository? _subscribeRepository;
    public IBookRepository BookRepository => _bookRepository ?? new BookRepository(_dbContext);
    public IReviewRepository ReviewRepository => _reviewRepository ??= new ReviewRepository(_dbContext);
    public IBlogRepository BlogRepository => _blogRepository ??= new BlogRepository(_dbContext);
    public IBookImageRepository BookImageRepository => _bookImageRepository ??= new BookImageRepository(_dbContext);
    public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_dbContext);    
    public IFormatRepository FormatRepository => _formatRepository ??= new FormatRepository(_dbContext);
    public ITypeRepository TypeRepository => _typeRepository ??= new TypeRepository(_dbContext);
    public ISubscribeRepository SubscribeRepository => _subscribeRepository ??= new SubscribeRepository(_dbContext);
    public IAuthorAwardRepository AuthorAwardRepository => throw new NotImplementedException();
    public IAuthorImageRepository AuthorImageRepository => throw new NotImplementedException();
    public IAuthorRepository AuthorRepository => _authorRepository ??= new AuthorRepository(_dbContext);
    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
