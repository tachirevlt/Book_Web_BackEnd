using MediatR;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public record GetBookByIdQuery(Guid BookId) : IRequest<BookEntity?>;

    public class GetBookByIdQueryHandler(IBookRepository bookRepository)
        : IRequestHandler<GetBookByIdQuery, BookEntity?>
    {
        public async Task<BookEntity?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await bookRepository.GetBookByIdAsync(request.BookId, cancellationToken);
        }
    }
}
