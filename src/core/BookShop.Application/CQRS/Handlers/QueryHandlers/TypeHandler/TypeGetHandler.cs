using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.TypeRequest;
using BookShop.Application.CQRS.Queries.Response.TypeResponse;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.TypeHandler;

public class TypeGetHandler : IRequestHandler<TypeGetRequest, TypeGetResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public TypeGetHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TypeGetResponse> Handle(TypeGetRequest request, CancellationToken cancellationToken)
    {
        E.Type? type = await _unitOfWork.TypeRepository.GetAsync(request.Id);
        if (type is null) throw new Exception(); //Todo: Exception
        return new TypeGetResponse(type.Id, type.Name);
    }
}
