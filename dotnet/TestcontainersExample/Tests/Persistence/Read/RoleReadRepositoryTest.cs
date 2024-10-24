using JetBrains.Annotations;
using TestcontainersExample.Persistence.Read;

namespace Tests.Persistence.Read;

[TestSubject(typeof(RoleReadRepository))]
public class RoleReadRepositoryTest(PostgresDatabaseFixture databaseFixture) : IClassFixture<PostgresDatabaseFixture>
{
    [Fact(DisplayName = "Get roles by name")]
    public void FindAllRolesTest()
    {
        var roles = new RoleReadRepository(databaseFixture.DataSource).All();
        Assert.NotEmpty(roles);
    }
}