using System.Threading.Tasks;

namespace Weather.DAL.Mongo
{
    public interface IMongoDbInitializer
    {
        Task InitializeAsync();
    }
}