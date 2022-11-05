using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Extensions;
using BookShop.Application.Extensions.FormFileExtensions;
using BookShop.Domain.Base;
using BookShop.Persistence.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Contracts.Common;

public class Validation : IValidation
{
    private readonly AppDbContext _dbContext;

    public Validation(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool CheckFile(IFormFile formFile)
        => formFile.CheckSize(5120) && formFile.CheckType("image");

    public bool CheckFile(IFormFileCollection formFiles)
        => formFiles.ToList().Any(f => f.CheckSize(5120) && f.CheckType("image"));

    public bool CheckFile(IEnumerable<IFormFile> formFiles)
         => formFiles.ToList().Any(f => f.CheckSize(5120) && f.CheckType("image"));

    public async Task<bool> UniqueAsync<T>(string name, CancellationToken token) where T : class,INormalizationName
    {
        if (await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.NormalizationName == name.CharacterRegulatory(int.MaxValue), cancellationToken: token) != null)
            return true;
        return false;
    }
}
