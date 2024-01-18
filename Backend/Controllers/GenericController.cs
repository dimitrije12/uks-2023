using Backend.Domain.Models;
using Backend.Services.Commands;
using Backend.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class GenericController<TEntity> : ControllerBase where TEntity : BaseEntity
{
    private readonly IMediator mediator;
    public GenericController(IMediator mediator)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

   
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetByIdQuery<TEntity>(id));

        return new OkObjectResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TEntity entity)
    {
       var result = await mediator.Send(new AddNewEntityCommand<TEntity>(entity));

        return new OkObjectResult(entity);
    }


    // ovo cemo posle
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TEntity entity)
    {
        return NotFound();

    }
    // ovo cemo posle
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return NotFound();

    }
}