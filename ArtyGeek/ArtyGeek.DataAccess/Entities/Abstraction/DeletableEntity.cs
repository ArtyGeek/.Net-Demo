namespace ArtyGeek.DataAccess.Entities.Abstraction
{
    public abstract class DeletableEntity
    {
        public bool IsDeleted { get; set; }
    }
}
