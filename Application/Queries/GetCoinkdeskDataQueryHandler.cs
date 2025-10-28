using MediatR;
using Core.Interfaces; 
using Core.Models;   
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