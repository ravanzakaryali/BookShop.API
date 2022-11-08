using BookShop.Domain.Base;

namespace BookShop.Application.Asbtarcts.Common;

public interface IValidation
{
    bool Unique<T>(string name) where T : class,INormalizationName;
}
