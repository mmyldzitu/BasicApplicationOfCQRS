using CQRS.CQRSFile.Commands;
using CQRS.CQRSFile.Handlers;
using CQRS.CQRSFile.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
       
        private readonly IMediator _mediator;
        public StudentsController( IMediator mediator)
        {
            
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _mediator.Send( new GetStudentByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task <IActionResult> GetStudent()
        {
            var result = await _mediator.Send(new GetStudentsQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task< IActionResult> CreateStudent(CreateStudentCommand command)
        {

            await _mediator.Send(command);
            return Created("",command.Name);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveStudent(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentCommand command)
        {
           await _mediator.Send(command);
            return NoContent();
        }
    }
}
