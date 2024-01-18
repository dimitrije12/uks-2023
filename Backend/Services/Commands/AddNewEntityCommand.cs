using Backend.Domain.Models;
using Backend.Infrastructure;
using MediatR;

namespace Backend.Services.Commands
{
    public class AddNewEntityCommand<TEntity> : IRequest<TEntity> where TEntity : BaseEntity
    {
        public AddNewEntityCommand(TEntity entity)
        {
            Entity = entity;   
        }
        public TEntity Entity { get; set; }
    }

    public class AddNewEntityCommandHandler<TEntity> : IRequestHandler<AddNewEntityCommand<TEntity>, TEntity>
    where TEntity : BaseEntity
    {
        private readonly DatabaseContext db;

        public AddNewEntityCommandHandler(DatabaseContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<TEntity> Handle(AddNewEntityCommand<TEntity> request, CancellationToken cancellationToken)
        {
            db.Set<TEntity>().Add(request.Entity);

            await db.SaveChangesAsync(cancellationToken);

            return request.Entity;
        }
    }
}
