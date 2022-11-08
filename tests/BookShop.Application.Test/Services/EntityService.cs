using BookShop.Application.Asbtarcts.Common;
using BookShop.Infrastructure.Contracts.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

namespace BookShop.Application.Test.Services;

public class EntityService<T> where T : class
{
    private readonly IValidation _validation;
    private readonly Mock<IApplicationDbContext> _dbContext;
    public EntityService()
    {
        var entity = Enumerable.Empty<T>().AsQueryable().BuildMock();

        _dbContext = new Mock<IApplicationDbContext>();

        Mock<DbSet<T>> mockEntity = new();

        mockEntity.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entity.Provider);
        mockEntity.As<IQueryable<T>>().Setup(a => a.Expression).Returns(entity.Expression);
        mockEntity.As<IQueryable<T>>().Setup(a => a.ElementType).Returns(entity.ElementType);
        mockEntity.As<IQueryable<T>>().Setup(a => a.GetEnumerator()).Returns(() => entity.GetEnumerator());
        _dbContext.Setup(a => a.Set<T>()).Returns(mockEntity.Object);
        _validation= new Validation(_dbContext.Object);
    }
    public IApplicationDbContext GetDbContext() => _dbContext.Object;
    public IValidation GetValidation() => _validation;
   
}
