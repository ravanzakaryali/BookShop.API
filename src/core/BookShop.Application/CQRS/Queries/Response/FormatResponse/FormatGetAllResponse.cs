using BookShop.Application.Common;

namespace BookShop.Application.CQRS.Queries.Response.FormatResponse;

public record FormatGetAllResponse : IMapFrom<Format>
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}
