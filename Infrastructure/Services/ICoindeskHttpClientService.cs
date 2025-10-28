using Core.Models;

namespace Infrastructure.Services
{
    public interface ICoindeskHttpClientService
    {
        Task<CoindeskData?> GetData(); // Thêm ?
    }
}