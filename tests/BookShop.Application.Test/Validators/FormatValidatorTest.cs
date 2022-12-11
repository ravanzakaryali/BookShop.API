using BookShop.Application.Test.Services;
using BookShop.Application.Test.TestData.EntitiesData;
using BookShop.Domain.Entities;

namespace BookShop.Application.Test.Validators;

public class FormatValidatorTest : FormatData
{
    private readonly EntityService<Format> _service;
	public FormatValidatorTest()
	{
		_service = new();
	}
}
