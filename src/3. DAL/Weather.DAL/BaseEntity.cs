using System;

namespace Weather.DAL
{
    public class BaseEntity : IIdentifiable
    {
        public BaseEntity(Guid id)
        {
            Id = id;
            CreatedDate = DateTime.UtcNow;
            SetUpdatedDate();
        }

        public DateTime CreatedDate { get; protected set; }
        public DateTime UpdatedDate { get; protected set; }
        public Guid Id { get; set; }

        private void SetUpdatedDate()
        {
            UpdatedDate = DateTime.UtcNow;
        }
    }
}