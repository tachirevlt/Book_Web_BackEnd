using MediatR;
using Application.Events;
using Core.Entities;
using Core.Interfaces; 

namespace Application.Commands
{
    public record AddBookCommand(BookEntity Book) : IRequest<BookEntity>;


    public class AddBookCommandHandler(IBookRepository bookRepository, IPublisher mediator)
        : IRequestHandler<AddBookCommand, BookEntity>
    {
        public async Task<BookEntity> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            
            if (request.Book.Id == Guid.Empty)
            {
                request.Book.Id = Guid.NewGuid();
            }
            var createdBook = await bookRepository.AddBookAsync(request.Book);

            // Publish sự kiện liên quan đến sách (cần tạo class BookCreatedEvent)
            await mediator.Publish(new BookCreatedEvent(createdBook.Id), cancellationToken); // Giả sử bạn tạo BookCreatedEvent

            return createdBook;
        }
    }
}
