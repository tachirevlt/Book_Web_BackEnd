using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;

        public BookRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<BookEntity?> GetBookByIdAsync(Guid id, CancellationToken ct = default)
        {
            var book = await _db.Books.FindAsync(new object?[] { id }, ct);
            // Xử lý trường hợp không tìm thấy nếu cần (ví dụ throw exception)
            if (book == null) throw new KeyNotFoundException($"Không tìm thấy sách với ID: {id}");
            return book;
        }

        public async Task<BookEntity> AddBookAsync(BookEntity book, CancellationToken ct = default)
        {
            await _db.Books.AddAsync(book, ct);
            await _db.SaveChangesAsync(ct);
            return book; // Trả về entity đã được thêm (EF Core sẽ cập nhật ID)
        }

        public async Task<BookEntity> UpdateBookAsync(Guid bookId, BookEntity updatedBookData, CancellationToken ct = default)
        {
            var existingBook = await _db.Books.FindAsync(new object?[] { bookId }, ct);
            if (existingBook is null)
            {
                // Nên throw exception hoặc trả về null/Result pattern tùy thiết kế
                throw new KeyNotFoundException($"Không tìm thấy sách với ID: {bookId}");
            }

            // Cập nhật các thuộc tính cần thiết từ updatedBookData vào existingBook
            existingBook.title = updatedBookData.title;
            existingBook.authors = updatedBookData.authors;
            existingBook.year = updatedBookData.year;
            // ... cập nhật các trường khác ...

            _db.Books.Update(existingBook); // Update entity đã được track
            await _db.SaveChangesAsync(ct);
            return existingBook; // Trả về entity đã được cập nhật
        }

        public async Task<bool> DeleteBookAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _db.Books.FindAsync(new object?[] { id }, ct);
            if (entity is null)
            {
                return false; // Không tìm thấy để xóa
            }
            _db.Books.Remove(entity);
            await _db.SaveChangesAsync(ct);
            return true; // Xóa thành công
        }
    }
}
