using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Weather.BLL.ApiModels.In;
using Weather.BLL.ApiModels.Out;
using Weather.DAL.Models;

namespace Weather.BLL
{
    public class BLLProfile : Profile
    {
        public BLLProfile()
        {
            CreateMap<Device, DeviceViewModel>();
            CreateMap<DeviceBindingModel, Device>();
            CreateMap<Measurement, MeasurmentViewModel>();
            CreateMap< MeasurmentBindingModel, Measurement>();
        }
    }
}
