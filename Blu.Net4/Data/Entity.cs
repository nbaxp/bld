using System;

namespace Blu.Net4.Data
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}