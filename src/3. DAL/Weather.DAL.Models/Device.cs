using System;

namespace Weather.DAL.Models
{
    public class Device : IIdentifiable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}