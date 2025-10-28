using MediatR;
using Core.Models; 

namespace Application.Queries
{

    public record GetJokeQuery() : IRequest<JokeModel?>;
}