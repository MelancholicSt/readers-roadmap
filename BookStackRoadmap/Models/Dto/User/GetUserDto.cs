namespace BookStackRoadmap.Models;

public class GetUserDto
{
    public string Id { get; set; }
    public string nickname { get; set; }
    public string email { get; set; }
    public string? phone_number;
    public bool is_verified { get; set; }
}