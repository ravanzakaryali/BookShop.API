using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.FormatRequest;
using BookShop.Application.CQRS.Queries.Response.FormatResponse;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.FormatHandler;
public class FormatGetHandler : IRequestHandler<FormatGetRequest, FormatGetResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public FormatGetHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<FormatGetResponse> Handle(FormatGetRequest request, CancellationToken cancellationToken)
    {
        Format? format = await _unitOfWork.FormatRepository.GetAsync(request.Id);
        if (format is null) throw new Exception("Format not found"); //Todo: Exception
        return new FormatGetResponse { Id = format.Id, Name = format.Name };
    }
}
