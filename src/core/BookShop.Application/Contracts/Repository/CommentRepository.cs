using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Contracts.Repository.Base;

namespace BookShop.Application.Contracts.Repository;
public class CommentRepository : Repository<IApplicationDbContext, Comment, string>
{
    public CommentRepository(IApplicationDbContext context) : base(context)
    {
    }
}
