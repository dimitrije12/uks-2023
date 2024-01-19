using Backend.Domain.Exceptions;
using Backend.Domain.Models;
using Backend.Dto;
using Backend.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Queries
{
    public class GetByIdQuery<TEntity> : IRequest<GenericGetByIdResponse<TEntity>> where TEntity : BaseEntity
    {
        public GetByIdQuery(long id)
        {
            this.Id = id;
        }
        public long Id { get; set; }
    }

    public class GetByIdQueryHandler<TEntity> : IRequestHandler<GetByIdQuery<TEntity>, GenericGetByIdResponse<TEntity>>
        where TEntity : BaseEntity
    {
        private readonly DatabaseContext db;
        public GetByIdQueryHandler(DatabaseContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<GenericGetByIdResponse<TEntity>> Handle(GetByIdQuery<TEntity> request, CancellationToken cancellationToken)
        {
            var entity = await  db.Set<TEntity>().Where(x => x.Id == request.Id).SingleOrDefaultAsync();

            if (entity is null)
            {
                throw new EntityNotFoundException<TEntity>(request.Id);
            }

            return new GenericGetByIdResponse<TEntity>(entity);
        }
    }


}
