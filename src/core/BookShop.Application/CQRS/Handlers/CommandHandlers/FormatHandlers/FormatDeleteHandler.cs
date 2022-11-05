using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.FormatResponse;
using BookShop.Application.CQRS.Commands.Request.FormatRequest;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.FormatHandlers;

public class FormatDeleteHandler : IRequestHandler<FormatDeleteRequest,FormatDeleteResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public FormatDeleteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<FormatDeleteResponse> Handle(FormatDeleteRequest request, CancellationToken cancellationToken)
    {
        Format? format = await _unitOfWork.FormatRepository.GetAsync(request.Id);
        if (format is null) throw new Exception("Format not found");
        Format deletedFormat = _unitOfWork.FormatRepository.Remove(format);
        await _unitOfWork.SaveChangesAsync();
        return new FormatDeleteResponse(deletedFormat.Id);
    }
}
