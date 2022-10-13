using Microsoft.AspNetCore.Http;

namespace BookShop.Application.Extensions.FormFileExtensions;

public static class FormFileExtensions
{
    public static bool CheckType(this IFormFile file, params string[] contentTypes) =>
             contentTypes.All(f => file.ContentType.ToLower().Contains(f.ToLower()));
    public static bool CheckSize(this IFormFile file, int maxKb = 1024, int minKb = 0)
        => file.Length / 1024 <= maxKb && file.Length > minKb;
}
