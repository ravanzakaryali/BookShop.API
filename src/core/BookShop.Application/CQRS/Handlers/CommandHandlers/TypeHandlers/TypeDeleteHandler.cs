using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.TypeResponse;
using BookShop.Application.CQRS.Commands.Request.TypeRequest;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.TypeHandlers;

public class TypeDeleteHandler : IRequestHandler<TypeDeleteRequest, TypeDeleteResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public TypeDeleteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TypeDeleteResponse> Handle(TypeDeleteRequest request, CancellationToken cancellationToken)
    {
        E.Type? type = await _unitOfWork.TypeRepository.GetAsync(request.Id);
        if (type is null) throw new Exception("Type not found"); //Todo: Type
        _unitOfWork.TypeRepository.Remove(type);
        await _unitOfWork.SaveChangesAsync();
        return new TypeDeleteResponse(type.Id);
    }
}
