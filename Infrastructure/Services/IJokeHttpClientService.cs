using Core.Models;

namespace Infrastructure.Services
{
    public interface IJokeHttpClientService
    {
        Task<JokeModel> GetData();
    }
}