using System;

namespace Weather.BLL.ApiModels.In
{
    public class DeviceBindingModel 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
