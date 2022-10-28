using System.Text.Json.Serialization;

namespace WebAPIClient.Models;

public class Player
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Number { get; set; }
    public string? Position { get; set; }
    public string? Line { get; set; }
}