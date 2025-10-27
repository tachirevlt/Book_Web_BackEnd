using MediatR;
using Core.Entities;
using Core.Interfaces;

namespace Application.Commands
{
    public record UpdateBookCommand(Guid BookId, BookEntity Book)
        : IRequest<BookEntity>;
    public class UpdateBookCommandHandler(IBookRepository bookRepository)
        : IRequestHandler<UpdateBookCommand, BookEntity>
    {
        public async Task<BookEntity> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            return await bookRepository.UpdateBookAsync(request.BookId, request.Book);
        }
    }
}
