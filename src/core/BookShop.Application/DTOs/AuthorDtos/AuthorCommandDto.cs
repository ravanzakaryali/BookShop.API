using Microsoft.AspNetCore.Http;

namespace BookShop.Application.DTOs.AuthorDtos;

public class AuthorCommandDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
