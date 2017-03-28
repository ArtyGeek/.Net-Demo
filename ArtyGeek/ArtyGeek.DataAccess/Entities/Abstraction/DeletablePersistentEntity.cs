namespace ArtyGeek.DataAccess.Entities.Abstraction
{
    public abstract class DeletablePersistentEntity : DeletableEntity
    {
        public int Id { get; set; }
    }
}
