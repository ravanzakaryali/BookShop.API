namespace BookShop.Domain.Base;


public class BaseAuditableEntity : BaseAuditableEntity<string>
{

}
public class BaseAuditableEntity<TKey> : BaseEntity<TKey> where TKey : IEquatable<TKey>
{
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string? LastModifedBy { get; set; }
}
