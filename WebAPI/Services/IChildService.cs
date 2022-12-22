using WebAPI.Models;

namespace WebAPI.Services;

public interface IChildService
{
    Task<IList<Child>> GetChildrenAsync();
    Task<Child> GetChildAsync(int id);
    Task<Child> SaveChildAsync(Child child);
    Task<Child> EditChildAsync(Child child);
    Task<bool> DeleteChildAsync(int id);
}