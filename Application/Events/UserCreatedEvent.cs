using MediatR;

namespace Application.Events;

public record UserCreatedEvent(Guid UserId) : INotification;
