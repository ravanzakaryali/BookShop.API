﻿using BookShop.Application.CQRS.Commands.Reponse.CategoryResponse;

namespace BookShop.Application.CQRS.Commands.Request.CategoryRequest;

public record CategoryCreateRequest(string Name) : IRequest<CategoryCreateResponse>;
