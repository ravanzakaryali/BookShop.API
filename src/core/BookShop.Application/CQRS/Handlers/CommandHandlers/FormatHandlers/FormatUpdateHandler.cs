using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.FormatResponse;
using BookShop.Application.CQRS.Commands.Request.FormatRequest;
using BookShop.Application.Exceptions;
using BookShop.Application.Extensions;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.FormatHandlers;

public class FormatUpdateHandler : IRequestHandler<FormatUpdateRequest, FormatUpdateResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public FormatUpdateHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<FormatUpdateResponse> Handle(FormatUpdateRequest request, CancellationToken cancellationToken)
    {
        Format? format = await _unitOfWork.FormatRepository.GetAsync(request.Id);
        if (format is null) throw new EntityNotFoundException<Format,string>(request.Id);
        if (_unitOfWork.FormatRepository.GetAsync(c => c.NormalizationName == request.Format.Name.CharacterRegulatory(int.MaxValue)) != null)
        {
            throw new Exception("Already"); //TODO: Already Exception
        }
        format.Name = request.Format.Name;
        await _unitOfWork.SaveChangesAsync();
        return new FormatUpdateResponse();
    }
}
