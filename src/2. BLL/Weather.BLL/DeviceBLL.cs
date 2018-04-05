using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Weather.BLL.ApiModels;
using Weather.BLL.ApiModels.In;
using Weather.BLL.ApiModels.Out;
using Weather.DAL.Context;

namespace Weather.BLL
{
    public class DeviceBLL
    {
        private readonly AppDbContext _db;

        //TODO WŻ - czy dobrze użyty mapper
        private readonly MapperConfiguration _mapperConfiguration;

        public DeviceBLL(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public DeviceViewModel Get(int id)
        {
            var mapper = _mapperConfiguration.CreateMapper();

            var deviceEntity = _db.Devices.FirstOrDefault(device => device.Id == id);
            DeviceViewModel viewModel = mapper.Map<DeviceViewModel>(deviceEntity);

            return viewModel;
        }

        public DeviceViewModel Get(string name)
        {
            var mapper = _mapperConfiguration.CreateMapper();

            var deviceEntity = _db.Devices.FirstOrDefault(device => device.Name == name);
            DeviceViewModel viewModel = mapper.Map<DeviceViewModel>(deviceEntity);

            return viewModel;
        }

        public IEnumerable<DeviceViewModel> GetAllDevices()
        {
            var mapper = _mapperConfiguration.CreateMapper();

            var devices = _db.Devices.Select(device => mapper.Map<DeviceViewModel>(device)).ToList();

            return devices;
        }

        public void Save(DeviceBindingModel deviceBinding)
        {


            //var any = _db.Devices.First(device => device.Name )
        }
    }
}
