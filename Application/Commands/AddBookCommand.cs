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
            // Sửa tên biến và gọi phương thức AddBookAsync đã sửa ở bước 2
            var createdBook = await bookRepository.AddBookAsync(request.Book, cancellationToken);

            // Publish sự kiện liên quan đến sách (cần tạo class BookCreatedEvent)
            await mediator.Publish(new BookCreatedEvent(createdBook.Id), cancellationToken); // Giả sử bạn tạo BookCreatedEvent

            return createdBook;
        }
    }
}
