using BookShop.Application.Common;

namespace BookShop.Application.CQRS.Queries.Response.TypeResponse;

public class TypeGetAllResponse : IMapFrom<E.Type>
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}
