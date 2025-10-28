// File: Application/Queries/GetJokeQueryHandler.cs
using MediatR;
using Core.Interfaces; // Namespace chứa IExternalVendorRepository
using Core.Models;    // Namespace chứa JokeModel
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