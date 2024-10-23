using Npgsql;
using TestcontainersExample.Domain;

namespace TestcontainersExample.Persistence.Read;

public class RoleReadRepository(NpgsqlDataSource dataSource)
{
    public Role? FindById(long id)
    {
        using var command =
            dataSource.CreateCommand(
                $"SELECT {RoleTable.Id}, {RoleTable.Name} FROM {RoleTable.TableName} WHERE {RoleTable.Id}=$1");
        command.Parameters.AddWithValue(id);
        using var reader = command.ExecuteReader();
        return reader.Read() ? MapFromReader(reader) : null;
    }

    public IList<Role> All()
    {
        var command = dataSource.CreateCommand($"SELECT {RoleTable.Id}, {RoleTable.Name} FROM {RoleTable.TableName}");
        using var reader = command.ExecuteReader();
        var roles = new List<Role>();
        while (reader.Read())
        {
            roles.Add(MapFromReader(reader));
        }
        return roles;
    }

    private static Role MapFromReader(NpgsqlDataReader reader)
    {
        return new Role()
        {
            Id = reader.GetInt64(0),
            Name = reader.GetString(1)
        };
    }
}