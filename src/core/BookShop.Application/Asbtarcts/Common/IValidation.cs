using BookShop.Domain.Base;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices;

namespace BookShop.Application.Asbtarcts.Common;

public interface IValidation
{
    bool CheckFile(IFormFile formFile);
    bool CheckFile(IFormFileCollection formFiles);
    bool CheckFile(IEnumerable<IFormFile> formFiles);
    Task<bool> UniqueAsync<T>(string name,CancellationToken token) where T : class,INormalizationName;
}
