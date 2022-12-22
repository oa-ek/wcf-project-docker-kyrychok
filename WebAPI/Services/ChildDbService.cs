using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Services;

public class ChildDbService : IChildService
{
    private KinderGardenContext context;

    public ChildDbService(KinderGardenContext context)
    {
        this.context = context;
    }

    public async Task<IList<Child>> GetChildrenAsync()
    {
        return context.Children
            .Include(b => b.Toys)
            .ToList();
    }

    public async Task<Child> GetChildAsync(int id)
    {
        return await context.Children.FirstAsync(child => child.Id == id);
    }

    public async Task<Child> SaveChildAsync(Child child)
    {
        var returnValue = await context.Children.AddAsync(child);
        await context.SaveChangesAsync();
        return returnValue.Entity;
    }

    public async Task<Child> EditChildAsync(Child child)
    {
        throw new NotImplementedException();
        try
        {
            var toUpdate = await context.Children.FirstAsync(b => b.Id == child.Id);

            //todo update
            // toUpdate.Title = child.Title;

            context.Update(toUpdate);
            await context.SaveChangesAsync();
            return toUpdate;
        }
        catch (Exception e)
        {
            throw new Exception($"Did not find child with id{child.Id}");
        }
    }

    public async Task<bool> DeleteChildAsync(int id)
    {
        var toDelete = await context.Children.FirstOrDefaultAsync(b => b.Id == id);
        if (toDelete == null) return false;

        context.Children.Remove(toDelete);
        await context.SaveChangesAsync();
        return true;
    }
}