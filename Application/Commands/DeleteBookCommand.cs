using MediatR;
using Core.Interfaces;

namespace Application.Commands
{
    public record DeleteBookCommand(Guid BookId) : IRequest<bool>;

    internal class DeleteBookCommandHandler(IBookRepository bookRepository)
        : IRequestHandler<DeleteBookCommand, bool>
    {
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await bookRepository.DeleteBookAsync(request.BookId);
        }
    }
}
