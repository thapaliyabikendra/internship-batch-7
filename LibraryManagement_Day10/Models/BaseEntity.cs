namespace LibraryManagement_Day10.Models;

//public class BaseEntity<T>
//{
//    public required T Id =Guid.NewGuid();
//    public string? Name { get; set; }
//}
public class BaseEntity<T> where T : struct
{
    public T Id { get; set; }

    public BaseEntity()
    {
        if (typeof(T) == typeof(Guid))
        {
            Id = (T)(object)Guid.NewGuid();
        }
    }
    public string? Name { get; set; }

}