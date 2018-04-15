using System;
using System.Threading.Tasks;
using Weather.DAL.Models;
using Weather.DAL.Mongo;

namespace Weather.DAL.Repositories.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IMongoRepository<Device> _repository;

        public DeviceRepository(IMongoRepository<Device> repository)
        {
            _repository = repository;
        }

        public Task<Device> GetAsync(Guid id)
        {
            return _repository.GetAsync(id);
        }

        public Task CreateAsync(Device product)
        {
            return _repository.CreateAsync(product);
        }

        public Task UpdateAsync(Device product)
        {
            return _repository.UpdateAsync(product);
        }

        public Task DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}