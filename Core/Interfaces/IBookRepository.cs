using Core.Entities;
using System;
using System.Threading; // Thêm using này
using System.Threading.Tasks; // Thêm using này

namespace Core.Interfaces
{
    public interface IBookRepository
    {
        // Thêm CancellationToken vào các phương thức async
        Task<BookEntity?> GetBookByIdAsync(Guid id, CancellationToken ct = default);
        Task<BookEntity> AddBookAsync(BookEntity entity, CancellationToken ct = default);
        Task<BookEntity> UpdateBookAsync(Guid bookId, BookEntity entity, CancellationToken ct = default); // Đổi tên tham số từ employeeId thành bookId cho rõ ràng
        Task<bool> DeleteBookAsync(Guid bookId, CancellationToken ct = default); // Đổi tên tham số
    }
}