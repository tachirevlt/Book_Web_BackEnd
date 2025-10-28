using MediatR;
using Core.Interfaces; 
using Core.Models;    
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetJokeQueryHandler(IExternalVendorRepository externalVendorRepository)
        : IRequestHandler<GetJokeQuery, JokeModel?>
    {
        public async Task<JokeModel?> Handle(GetJokeQuery request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetJoke();
        }
    }   
}