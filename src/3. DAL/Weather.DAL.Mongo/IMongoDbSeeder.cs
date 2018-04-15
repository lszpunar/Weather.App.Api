using System.Threading.Tasks;

namespace Weather.DAL.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}