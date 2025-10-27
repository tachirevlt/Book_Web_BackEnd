// File: Application/Queries/GetJokeQueryHandler.cs
using MediatR;
using Core.Interfaces; // Namespace chứa IExternalVendorRepository
using Core.Models;    // Namespace chứa JokeModel
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    // Class này xử lý GetJokeQuery.
    // Nó implement IRequestHandler<GetJokeQuery, JokeModel>.
    public class GetJokeQueryHandler(IExternalVendorRepository externalVendorRepository)
        : IRequestHandler<GetJokeQuery, JokeModel>
    {
        // Inject IExternalVendorRepository thông qua constructor (Primary Constructor).

        // Phương thức Handle sẽ được MediatR gọi khi có GetJokeQuery.
        public async Task<JokeModel> Handle(GetJokeQuery request, CancellationToken cancellationToken)
        {
            // Gọi phương thức GetJoke() từ repository đã inject.
            return await externalVendorRepository.GetJoke(); //
        }
    }
}