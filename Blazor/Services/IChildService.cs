using WebAPI.Models;

namespace Blazor.Services;

public interface IChildService
{
    Task<IList<Child>> GetChildrenAsync();
    Task<Child> GetChildAsync(int id);
    Task<Child> AddChildAsync(Child child);

    Task<Child> EditChildAsync(Child child);
    Task<bool> DeleteChildAsync(int id);
}