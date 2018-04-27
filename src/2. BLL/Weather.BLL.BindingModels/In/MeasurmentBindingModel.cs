using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.BLL.ApiModels.In
{
    public class MeasurmentBindingModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Guid DeviceId { get; set; }
        public decimal Value { get; set; }
        public string Unite { get; set; }
    }
}
