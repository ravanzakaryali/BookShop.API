using BookShop.Application.Asbtarcts.Common;

namespace BookShop.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
