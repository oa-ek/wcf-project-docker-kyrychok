using System.Text;
using System.Text.Json;
using WebAPI.Models;

namespace Blazor.Services;

public class ToyWebService : IToyService
{
    
    private string uri = "https://localhost:7223";

    // private string uri = "http://jsonplaceholder.typicode.com";
    private readonly HttpClient client;

    public ToyWebService()
    {
        client = new HttpClient();
    }
    
    public async Task<IList<Toy>> GetToysAsync()
    {
        HttpResponseMessage response = await client.GetAsync(uri + "/Toy");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        }

        string message = await response.Content.ReadAsStringAsync();
        List<Toy> result = JsonSerializer.Deserialize<List<Toy>>(message);
        return result;
    }

    public Task<Toy> GetToyAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Toy> AddToyAsync(Toy toy, int childId)
    {
        string toyAsJson = JsonSerializer.Serialize(toy);
        HttpContent content = new StringContent(toyAsJson,
            Encoding.UTF8,
            "application/json");
        HttpResponseMessage response = await client.PostAsync(uri + $"/toy/owner/{childId}", content);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
        }
        string message = await response.Content.ReadAsStringAsync();
        Toy result = JsonSerializer.Deserialize<Toy>(message);
        return result;
    }

    public Task<Toy> EditToyAsync(Toy toy)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteToyAsync(int id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"{uri}/toy/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"{response.StatusCode};{response.ReasonPhrase}");
        }

        string message = await response.Content.ReadAsStringAsync();
        bool result = JsonSerializer.Deserialize<bool>(message);
        return result;
    }
}