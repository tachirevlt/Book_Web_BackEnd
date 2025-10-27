// File: Application/Queries/GetCoinkdeskDataQueryHandler.cs
using MediatR;
using Core.Interfaces; // Namespace chứa IExternalVendorRepository
using Core.Models;    // Namespace chứa CoindeskData
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    // Class này xử lý GetCoinkdeskDataQuery.
    // Nó implement IRequestHandler<GetCoinkdeskDataQuery, CoindeskData>.
    public class GetCoinkdeskDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        : IRequestHandler<GetCoinkdeskDataQuery, CoindeskData>
    {
        // Inject IExternalVendorRepository thông qua constructor (Primary Constructor).

        // Phương thức Handle sẽ được MediatR gọi khi có GetCoinkdeskDataQuery.
        public async Task<CoindeskData> Handle(GetCoinkdeskDataQuery request, CancellationToken cancellationToken)
        {
            // Gọi phương thức GetData() từ repository đã inject.
            return await externalVendorRepository.GetData(); //
        }
    }
}