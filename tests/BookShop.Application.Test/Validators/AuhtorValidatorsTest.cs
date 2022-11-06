using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using BookShop.Application.Test.TestData.EntitiesData;
using BookShop.Application.Validators.AuthorValidator;
using BookShop.Domain.Entities;
using BookShop.Infrastructure.Contracts.Common;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using Moq;
using MockQueryable.Moq;

namespace BookShop.Application.Test.Validators;

public class AuhtorValidatorsTest : AuhtorData
{
    private readonly IValidation _validation;
    private readonly Mock<DbSet<Author>> mockAuthor;
    private readonly Mock<IApplicationDbContext> _dbContext;
    public AuhtorValidatorsTest()
    {
        var author = Enumerable.Empty<Author>().AsQueryable().BuildMock();
        _dbContext = new Mock<IApplicationDbContext>();
        mockAuthor = new Mock<DbSet<Author>>();
        mockAuthor.As<IQueryable<Author>>().Setup(m => m.Provider).Returns(author.Provider);
        mockAuthor.As<IQueryable<Author>>().Setup(a => a.Expression).Returns(author.Expression);
        mockAuthor.As<IQueryable<Author>>().Setup(a => a.ElementType).Returns(author.ElementType);
        mockAuthor.As<IQueryable<Author>>().Setup(m => m.GetEnumerator()).Returns(() => author.GetEnumerator());
        _dbContext.Setup(a => a.Set<Author>()).Returns(mockAuthor.Object);
        _validation = new Validation(_dbContext.Object);
    }

    [Theory, MemberData(nameof(AuthorCreateRequest))]
    public async Task AuhtorCreateValidation_AuthorCreateRequest_ReturnError(AuthorCreateRequest authorCreateRequest)
    {
        AuthorCreateValidator validation = new(_validation);
        TestValidationResult<AuthorCreateRequest> result = await validation.TestValidateAsync(authorCreateRequest);
        result.ShouldHaveAnyValidationError();
    }
}
