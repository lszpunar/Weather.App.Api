using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Weather.BLL.ApiModels;
using Weather.BLL.ApiModels.In;
using Weather.BLL.ApiModels.Out;
using Weather.DAL.Context;
using Weather.DAL.Models;

namespace Weather.BLL
{
    public class DeviceBLL
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger _log;

        public DeviceBLL(AppDbContext db, IMapper mapper, ILogger log)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public async Task<DeviceViewModel> GetAsync(int id)
        {
            var deviceEntity = await _db.Devices.FirstOrDefaultAsync(device => device.Id == id);
            DeviceViewModel viewModel = _mapper.Map<DeviceViewModel>(deviceEntity);

            return viewModel;
        }

        public async Task<DeviceViewModel> GetAsync(string name)
        {
            var deviceEntity = await _db.Devices.FirstOrDefaultAsync(device => device.Name == name);
            DeviceViewModel viewModel = _mapper.Map<DeviceViewModel>(deviceEntity);

            return viewModel;
        }

        public async Task<IEnumerable<DeviceViewModel>> GetAllDevicesAsync()
        {
            var devices = await _db.Devices.Select(device => _mapper.Map<DeviceViewModel>(device)).ToListAsync();

            return devices;
        }

        public async Task<bool> SaveAsync(DeviceBindingModel deviceBinding)
        {
            bool result = true;

            try
            {
                var device = await _db.Devices.FirstOrDefaultAsync(dev => dev.Id == deviceBinding.Id);

                if (device == null)
                {
                    device = new Device();
                    _db.Devices.Add(device);
                }

                device.Description = deviceBinding.Description;
                device.Name = deviceBinding.Name;
                
                await _db.SaveChangesAsync();
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}
