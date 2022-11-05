namespace BookShop.Application.CQRS.Queries.Response.FormatResponse;

public record FormatGetResponse
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}
