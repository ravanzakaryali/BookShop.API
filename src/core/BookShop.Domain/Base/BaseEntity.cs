namespace BookShop.Domain.Base;

public class BaseEntity : BaseEntity<string>
{

}
public class BaseEntity<TKey> where TKey : IEquatable<TKey>
{
    public virtual TKey Id { get; set; } = default!;
    public virtual bool IsDeleted { get; set; } = default; 
}
