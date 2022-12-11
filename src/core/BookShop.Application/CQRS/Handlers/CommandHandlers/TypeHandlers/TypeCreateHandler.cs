using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.TypeResponse;
using BookShop.Application.CQRS.Commands.Request.TypeRequest;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.TypeHandlers;

public class TypeCreateHandler : IRequestHandler<TypeCreateRequest, TypeCreateResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public TypeCreateHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TypeCreateResponse> Handle(TypeCreateRequest request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.TypeRepository.IsExistAsync(request.Name)) throw new Exception("Already ex"); //TODO: Already exc
        E.Type type = await _unitOfWork.TypeRepository.AddAsync(new E.Type
        {
            Name = request.Name
        });
        await _unitOfWork.SaveChangesAsync();
        return new TypeCreateResponse(type.Id);
    }
}
