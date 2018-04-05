using System;

namespace Weather.DAL.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int DeviceId { get; set; }
        public decimal Value { get; set; }
        public string Unite { get; set; }

        public Device Device { get; set; }
    }
}
