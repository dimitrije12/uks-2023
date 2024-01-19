using Backend.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProjectController : GenericController<Project>
    {
        public ProjectController(IMediator mediator) : base(mediator)
        {
        }
    }
}
