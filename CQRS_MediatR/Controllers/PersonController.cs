using CQRS_MediatR.Cqrs.Commands;
using CQRS_MediatR.Cqrs.Queries;
using CQRS_MediatR.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            var res = await _mediator.Send(new GetAllPeopleQuery());
            return res;
            //var json = JsonSerializer.Serialize(res);
            //return new JsonResult(res);
        }

        //#################

        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await _mediator.Send(new GetPersonByIdQuery(id));
        }

        //#################
        [HttpPost]
        public async Task<IActionResult> Add(AddPersonCommand person)
        {
            var id = await _mediator.Send(new AddPersonCommand
            {
                Name = person.Name,
                Age = person.Age
            });
            return RedirectToAction("Get", new { id = id });
        }
        //#################

        [HttpPut]
        public async Task<Person> Edit(UpdatePersonCommand person)
        {
            var result = await _mediator.Send(new UpdatePersonCommand
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age
            });
            return result;
        }
        //#################

        [HttpDelete]
        public async Task<IEnumerable<Person>> Delete(int id)
        {
            var res= await _mediator.Send(new DeletePersonCommand
            {
                Id = id
            });
            return res ;
        }
        //#################
    }
}
