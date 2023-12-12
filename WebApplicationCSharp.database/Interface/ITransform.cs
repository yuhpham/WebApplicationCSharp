namespace WebApplicationCSharp.database.Interface
{
    public interface ITransform<out T>
    {
        T Transform();
    }
}
