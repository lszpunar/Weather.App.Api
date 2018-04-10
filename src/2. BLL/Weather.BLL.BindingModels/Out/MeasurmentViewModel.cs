using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.BLL.ApiModels.Out
{
    public class MeasurmentViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int DeviceId { get; set; }
        public decimal Value { get; set; }
        public string Unite { get; set; }
    }
}
