using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Request;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.SubscribeHandlers;

internal class CreateSubscribeHandler : IRequestHandler<SubscribeCreateRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSubscribeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(SubscribeCreateRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.SubscribeRepository.AddAsync(new Subscribe
        {
            Email = request.Email.ToLower(),
        });
        return Unit.Value;
    }
}
