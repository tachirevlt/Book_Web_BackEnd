// File: Application/Events/BookCreatedEvent.cs
using MediatR;
using System;

namespace Application.Events
{
    // Định nghĩa record cho sự kiện sách được tạo
    // Nó kế thừa INotification để MediatR biết đây là một thông báo
    public record BookCreatedEvent(Guid BookId) : INotification;

    // Optional: Bạn có thể thêm một Notification Handler nếu cần xử lý sự kiện này
    // Ví dụ: Ghi log, gửi email,...
    // public class BookCreatedEventHandler : INotificationHandler<BookCreatedEvent>
    // {
    //     public Task Handle(BookCreatedEvent notification, CancellationToken cancellationToken)
    //     {
    //         Console.WriteLine($"Sách mới đã được tạo với ID: {notification.BookId}");
    //         return Task.CompletedTask;
    //     }
    // }
}