using System.Text;
using System.Text.Json;
using WebAPI.Models;

namespace Blazor.Services;

public class ChildWebService : IChildService
{
    private string uri = "https://localhost:7223";

    // private string uri = "http://jsonplaceholder.typicode.com";
    private readonly HttpClient client;

    public ChildWebService()
    {
        client = new HttpClient();
    }
    
    public async Task<IList<Child>> GetChildrenAsync()
    {
        HttpResponseMessage response = await client.GetAsync(uri + "/Child");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        }

        string message = await response.Content.ReadAsStringAsync();
        List<Child> result = JsonSerializer.Deserialize<List<Child>>(message);
        return result;
    }

    public Task<Child> GetChildAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Child> AddChildAsync(Child child)
    {
        string childAsJson = JsonSerializer.Serialize(child);
        HttpContent content = new StringContent(childAsJson,
            Encoding.UTF8,
            "application/json");
        
        HttpResponseMessage response = await client.PostAsync(uri + "/Child", content);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        }

        string message = await response.Content.ReadAsStringAsync();
        Child result = JsonSerializer.Deserialize<Child>(message);
        return result;
    }

    
    
    public Task<Child> EditChildAsync(Child child)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteChildAsync(int id)
    {
        throw new NotImplementedException();
    }
}