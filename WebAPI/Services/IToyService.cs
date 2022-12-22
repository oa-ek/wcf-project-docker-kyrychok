using WebAPI.Models;

namespace WebAPI.Services;

public interface IToyService
{
    Task<IList<Toy>> GetToysAsync();
    Task<Toy> GetToyAsync(int id);
    Task<Toy> SaveToyAsync(Toy toy, int childId);
    Task<Toy> EditToyAsync(Toy toy);
    Task<bool> DeleteToyAsync(int id);
}