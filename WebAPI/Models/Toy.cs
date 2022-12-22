using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

public class Toy
{
    [Required, Key]
    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [Required, MaxLength(20)]
    [JsonPropertyName("Name")]
    public String Name { get; set; }

    [JsonPropertyName("Color")] public String Color { get; set; }
    [JsonPropertyName("Condition")] public String Condition { get; set; }
    [JsonPropertyName("IsFavourite")] public bool IsFavourite { get; set; }
}