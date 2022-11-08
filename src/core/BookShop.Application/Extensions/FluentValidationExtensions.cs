using BookShop.Application.Extensions.FormFileExtensions;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.Extensions;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, TProperty> FilesSize<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, int maxSize, int minSize = 0) where TProperty : IFormFileCollection
        => ruleBuilder.Must(c => c.Any(f => f.CheckSize(maxSize, minSize)));

    public static IRuleBuilderOptions<T, TProperty> FilesType<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, params string[] contentTypes) where TProperty : IFormFileCollection
        => ruleBuilder.Must(c => c.Any(f => f.CheckType(contentTypes)));

    public static IRuleBuilderOptions<T, TProperty> FileSize<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, int maxSize, int minSize = 0) where TProperty : IFormFile
       => ruleBuilder.Must(f => f.CheckSize(maxSize, minSize));

    public static IRuleBuilderOptions<T, TProperty> FileType<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, params string[] contentTypes) where TProperty : IFormFile
        => ruleBuilder.Must(f => f.CheckType(contentTypes));

}
