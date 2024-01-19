using Backend.Domain.Models;

namespace Backend.Domain.Exceptions
{
    public class EntityNotFoundException<TEntity> : Exception where TEntity : BaseEntity
    {
        public EntityNotFoundException(long id)
            : base($"Entity of type {typeof(TEntity).Name} with Id {id} not found.")
        {
        }

        public EntityNotFoundException(long id, Exception innerException)
            : base($"Entity of type {typeof(TEntity).Name} with Id {id} not found.", innerException)
        {
        }
    }
}
