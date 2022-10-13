using AutoMapper;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.BookRequest;
using BookShop.Application.CQRS.Queries.Response.BookResponse;
using BookShop.Domain.Entities;
using MediatR;
using System.Collections;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.BookHandler;

public class GetAllBookQueryHandler : IRequestHandler<GetAllBooksQueryRequest, List<GetAllBookQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllBookQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<GetAllBookQueryResponse>> Handle(GetAllBooksQueryRequest request, CancellationToken cancellationToken)
    {
        List<Book> books = await _unitOfWork.BookRepository.GetAllAsync(request.Page, request.Size, r => r.Title, includes: "BookImages");
        List<GetAllBookQueryResponse> responses = new();
        IEnumerable<string> bookImages = books.SelectMany(b => b.BookImages).Where(b => b.IsMain == true).Select(b => b.Name);

        books.ForEach(b =>
        {
            BookImage? bookImage = b.BookImages.FirstOrDefault(b => b.IsMain == true);
            GetAllBookQueryResponse response = _mapper.Map<GetAllBookQueryResponse>(b);
            if (bookImage != null)
            {
                response.ImageUrl = bookImage.Path + bookImage.Name;
            }
            responses.Add(response);
        });
        return responses;
    }
}
