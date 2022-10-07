namespace SP.Data.Common
{
    public interface IEntity
    {
    }

    public abstract class BaseEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeleteDateTime { get; set; }
        public DateTime? LastChangeDateTime { get; set; }
    }

    public abstract class BaseEntityGuid : BaseEntity<Guid>
    {
    }

    public abstract class BaseEntityInt : BaseEntity<int>
    {
    }
}
