// Ví dụ tạo file Infrastructure/Repositories/ExternalVendorRepository.cs
using Core.Interfaces;
using Core.Models;
using Infrastructure.Services; // Assuming HttpClient services are here

namespace Infrastructure.Repositories
{
    public class ExternalVendorRepository(
        ICoindeskHttpClientService coindeskService,
        IJokeHttpClientService jokeService) : IExternalVendorRepository
    {
        public async Task<CoindeskData?> GetData()
        {
            // Gọi service tương ứng
            return await coindeskService.GetData();
        }

        public async Task<JokeModel?> GetJoke()
        {
            // Gọi service tương ứng
            return await jokeService.GetData();
        }
    }
}