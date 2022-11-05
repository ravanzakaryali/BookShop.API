using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.AuthorResponse;
using BookShop.Application.CQRS.Commands.Request.AuthorRequest;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.AuthorHandlers;

internal class AuthorDeleteHandler : IRequestHandler<AuthorDeleteRequest, AuthorDeleteResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthorDeleteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthorDeleteResponse> Handle(AuthorDeleteRequest request, CancellationToken cancellationToken)
    {
        Author? author = await _unitOfWork.AuthorRepository.GetAsync(request.Id);
        if (author is null) throw new Exception(); //Todo: Exception
        _unitOfWork.AuthorRepository.Remove(author);
        await _unitOfWork.SaveChangesAsync();
        return new AuthorDeleteResponse();
    }
}
