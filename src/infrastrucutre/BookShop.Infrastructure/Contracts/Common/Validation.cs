using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Extensions;
using BookShop.Domain.Base;

namespace BookShop.Infrastructure.Contracts.Common;

public class Validation : IValidation
{
    private readonly IApplicationDbContext _dbContext;

    public Validation(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public bool Unique<T>(string name) where T : class,INormalizationName
    {
        if (_dbContext.Set<T>().FirstOrDefault(e => e.NormalizationName == name.CharacterRegulatory(int.MaxValue)) != null)
            return false;
        return true;
    }
}
