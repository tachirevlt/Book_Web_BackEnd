using MediatR;
using Core.Models; 

namespace Application.Queries
{

    public record GetCoinkdeskDataQuery() : IRequest<CoindeskData?>;
}