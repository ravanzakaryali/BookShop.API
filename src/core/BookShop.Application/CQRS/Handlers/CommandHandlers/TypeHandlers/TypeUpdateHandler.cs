using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.TypeResponse;
using BookShop.Application.CQRS.Commands.Request.TypeRequest;
using BookShop.Application.Exceptions;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.TypeHandlers;

public class TypeUpdateHandler : IRequestHandler<TypeUpdateRequest, TypeUpdateResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public TypeUpdateHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TypeUpdateResponse> Handle(TypeUpdateRequest request, CancellationToken cancellationToken)
    {
        E.Type? type = await _unitOfWork.TypeRepository.GetAsync(request.Id);
        if (type is null) throw new EntityNotFoundException<E.Type,string>(request.Id);
        if (await _unitOfWork.TypeRepository.IsExistAsync(request.Type.Name)) throw new Exception("Already ex"); //TODO: Exception
        type.Name = request.Type.Name;
        await _unitOfWork.SaveChangesAsync();
        return new TypeUpdateResponse();
    }
}
