using System;

namespace Weather.DAL
{
    public interface IIdentifiable
    {
        Guid Id { get; set; }
    }
}