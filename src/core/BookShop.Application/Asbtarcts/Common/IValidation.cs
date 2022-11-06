using BookShop.Domain.Base;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.Asbtarcts.Common;

public interface IValidation
{
    bool CheckFile(IFormFile formFile);
    bool CheckFile(IFormFileCollection formFiles);
    bool CheckFile(IEnumerable<IFormFile> formFiles);
    bool Unique<T>(string name) where T : class,INormalizationName;
}
