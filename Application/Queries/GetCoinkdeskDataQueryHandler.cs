// File: Application/Queries/GetCoinkdeskDataQueryHandler.cs
using MediatR;
using Core.Interfaces; // Namespace chứa IExternalVendorRepository
using Core.Models;    // Namespace chứa CoindeskData
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{

    public class GetCoinkdeskDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        : IRequestHandler<GetCoinkdeskDataQuery, CoindeskData?>
    {
        public async Task<CoindeskData?> Handle(GetCoinkdeskDataQuery request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetData();
        }
    }
}