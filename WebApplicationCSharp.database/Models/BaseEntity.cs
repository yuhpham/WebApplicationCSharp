namespace WebApplicationCSharp.database.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreateAt { get; set; }




    }
}
