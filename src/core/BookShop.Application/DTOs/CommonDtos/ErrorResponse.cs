namespace BookShop.Application.DTOs.CommonDtos;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = null!;
}
