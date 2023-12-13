using System.Threading.Tasks;

namespace CmcMarkets.Backend.Tests.TestHarness
{
    public interface ISeedService
    {
        Task SeedUsersAndRoles();
        Task SeedUserTasks();
    }
}
