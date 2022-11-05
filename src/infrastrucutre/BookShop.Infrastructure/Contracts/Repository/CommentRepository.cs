using BookShop.Application.Asbtarcts.Common;
using BookShop.Infrastructure.Contracts.Repository.Base;
using BookShop.Persistence.Data;

namespace BookShop.Infrastructure.Contracts.Repository;
public class CommentRepository : Repository< Comment, string>
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }
}
