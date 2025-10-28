using Core.Entities;

namespace Core.Interfaces
{
    public interface IBookRepository
    {
        Task<BookEntity> GetBookByIdAsync(Guid id);
        Task<BookEntity> AddBookAsync(BookEntity entity);
        Task<BookEntity> UpdateBookAsync(Guid bookId, BookEntity entity);
        Task<bool> DeleteBookAsync(Guid bookId);
    }
}
