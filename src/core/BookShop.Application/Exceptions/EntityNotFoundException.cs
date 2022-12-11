using BookShop.Domain.Base;
using System.Runtime.Serialization;

namespace BookShop.Application.Exceptions;

public class EntityNotFoundException<TEntiy, TKey> : NotFoundException where TEntiy : BaseEntity<string>
{
    public EntityNotFoundException(TKey id) : base($"Entity {typeof(TEntiy).Name} with id {id} not found") { }
    public EntityNotFoundException(string? message) : base(message) { }
    public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
    protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}