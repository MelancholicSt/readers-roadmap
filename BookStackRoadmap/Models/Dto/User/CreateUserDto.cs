namespace BookStackRoadmap.Models;

public class CreateUserDto : IDto
{
    public string login { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string? phone_number { get; set; }
}