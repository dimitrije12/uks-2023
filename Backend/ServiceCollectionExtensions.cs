using Backend.Domain.Models;
using Backend.Dto;
using Backend.Services.Commands;
using Backend.Services.Queries;
using MediatR;

namespace Backend
{

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterGenericCrud(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AddNewEntityCommand<Project>, Project>, AddNewEntityCommandHandler<Project>>();
            services.AddTransient<IRequestHandler<GetByIdQuery<Project>, GenericGetByIdResponse<Project>>, GetByIdQueryHandler<Project>>();

            return services;
        }
    }
}
