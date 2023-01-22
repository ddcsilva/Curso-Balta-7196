using System;

namespace Todo.Domain.Entities
{
    public abstract class BaseEntity : IEquatable<BaseEntity>
    {
        protected BaseEntity(Guid id)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(BaseEntity other)
        {
            return Id == other.Id;
        }
    }
}