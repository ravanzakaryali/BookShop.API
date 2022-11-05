using BookShop.Application.Extensions;
using BookShop.Infrastructure.Contracts.Repository.Base;
using BookShop.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Contracts.Repository;

public class TypeRepository : Repository<E.Type, string>, ITypeRepository
{
    private readonly AppDbContext _context;
    public TypeRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsExistAsync(string name)
    {
        return await _context.Types.AnyAsync(t => t.NormalizationName == name.CharacterRegulatory(int.MaxValue));
    }
}
