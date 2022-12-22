using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Services;

public class ToyDbService : IToyService
{
    private KinderGardenContext context;

    public ToyDbService(KinderGardenContext context)
    {
        this.context = context;
    }

    public async Task<IList<Toy>> GetToysAsync()
    {
        return await context.Toys.ToListAsync();
    }

    public async Task<Toy> GetToyAsync(int id)
    {
        return await context.Toys.FirstAsync(f => f.Id == id);
    }

    public async Task<Toy> SaveToyAsync(Toy toy, int childId)
    {
        var addedToy = (await context.Toys.AddAsync(toy)).Entity;
        var childToEdit = await context.Children.FirstAsync(child => child.Id == childId);

        //add a list if the toy list is null
        if (childToEdit.Toys == null)
        {
            childToEdit.Toys = new List<Toy>();
        }
        childToEdit.Toys.Add(addedToy);
        
        await context.SaveChangesAsync();
        return addedToy;
    }

    public async Task<Toy> EditToyAsync(Toy toy)
    {
        throw new NotImplementedException();
        try
        {
            var toUpdate = await context.Toys.FirstAsync(f => f.Id == toy.Id);
            
            context.Update(toUpdate);
            await context.SaveChangesAsync();
            return toUpdate;
        }
        catch (Exception e)
        {
            throw new Exception($"Did not find toy with id{toy.Id}");
        }
    }

    public async Task<bool> DeleteToyAsync(int id)
    {
        var toDelete = await context.Toys.FirstOrDefaultAsync(f => f.Id == id);
        if (toDelete == null) return false;

        context.Toys.Remove(toDelete);
        await context.SaveChangesAsync();
        return true;
    }
}