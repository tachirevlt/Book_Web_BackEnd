using MediatR;
using System;

namespace Application.Events
{
    public record BookCreatedEvent(Guid BookId) : INotification;
}