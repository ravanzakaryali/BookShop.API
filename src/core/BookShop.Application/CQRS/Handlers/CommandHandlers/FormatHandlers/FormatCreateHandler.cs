using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.FormatResponse;
using BookShop.Application.CQRS.Commands.Request.FormatRequest;
using BookShop.Application.Extensions;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.FormatHandlers;

public class FormatCreateHandler : IRequestHandler<FormatCreateRequest, FormatCreateResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public FormatCreateHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<FormatCreateResponse> Handle(FormatCreateRequest request, CancellationToken cancellationToken)
    {
        if (_unitOfWork.FormatRepository.GetAsync(c => c.NormalizationName == request.Name.CharacterRegulatory(int.MaxValue)) != null)
        {
            throw new Exception("Already"); //Todo: Already Exception
        }
        Format? format = await _unitOfWork.FormatRepository.AddAsync(new Format
        {
            Name = request.Name
        });
        await _unitOfWork.SaveChangesAsync();
        return new FormatCreateResponse(format.Id);
    }
}
