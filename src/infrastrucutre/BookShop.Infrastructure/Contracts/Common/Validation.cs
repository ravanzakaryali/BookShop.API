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
    private readonly IApplicationDbContext _dbContext;

    public Validation(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool CheckFile(IFormFile formFile)
        => formFile.CheckSize(5120) && formFile.CheckType("image");

    public bool CheckFile(IFormFileCollection formFiles)
        => formFiles.ToList().Any(f => f.CheckSize(5120) && f.CheckType("image"));

    public bool CheckFile(IEnumerable<IFormFile> formFiles)
         => formFiles.ToList().Any(f => f.CheckSize(5120) && f.CheckType("image"));

    public bool Unique<T>(string name) where T : class,INormalizationName
    {
        if (_dbContext.Set<T>().FirstOrDefault(e => e.NormalizationName == name.CharacterRegulatory(int.MaxValue)) != null)
            return false;
        return true;
    }
}
