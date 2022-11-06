using BookShop.Application.Asbtarcts.Common;
using BookShop.Persistence.Data;
using BookShop.Persistence.Interceptor;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BookShop.Application.Test.Base;

internal class BaseServices
{
	public AppDbContext DbContext { get; }
	public BaseServices()
	{
		AuditableEntitySaveChangesInterceptor saveChangesInterceptor = new AuditableEntitySaveChangesInterceptor(new Mock<IDateTime>().Object, new Mock<IHttpContextAccessor>().Object);
        DbContext = new AppDbContext(new Mock<DbContextOptions<AppDbContext>>().Object, saveChangesInterceptor);
	}
}
