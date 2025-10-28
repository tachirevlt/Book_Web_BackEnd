
using Core.Models;

namespace Core.Interfaces;
public interface IExternalVendorRepository
{
    Task<CoindeskData?> GetData();
    Task<JokeModel?> GetJoke();
}