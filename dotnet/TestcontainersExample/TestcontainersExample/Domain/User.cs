namespace TestcontainersExample.Domain;

public class User
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public ISet<Role> Roles { get; set; } = new HashSet<Role>();
}