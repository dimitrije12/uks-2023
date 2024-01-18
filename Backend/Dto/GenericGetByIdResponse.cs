using Backend.Domain.Models;

namespace Backend.Dto
{
    public class GenericGetByIdResponse<T> where T : BaseEntity
    {

        public GenericGetByIdResponse(T entity)
        {
            this.Data = entity;
        }

        public T Data { get; set; }
    }
}
