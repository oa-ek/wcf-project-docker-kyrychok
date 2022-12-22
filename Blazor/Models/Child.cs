using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public class Child
{
    [Required, Key]
    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [Required, Range(3, 6)]
    [JsonPropertyName("Age")]
    public int Age { get; set; }

    [Required] [JsonPropertyName("Gender")] public string Gender { get; set; }
    [JsonPropertyName("Toys")] public List<Toy>? Toys { get; set; }
}