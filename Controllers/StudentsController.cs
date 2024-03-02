using CQRS.CQRSFile.Commands;
using CQRS.CQRSFile.Handlers;
using CQRS.CQRSFile.Queries;
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
        private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
        private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
        private readonly CreateCommandHandler _createCommandHandler;
        private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;
        public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler, CreateCommandHandler createCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        {
            _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
            _getStudentsQueryHandler = getStudentsQueryHandler;
            _createCommandHandler = createCommandHandler;
            _removeStudentCommandHandler = removeStudentCommandHandler;
            _updateStudentCommandHandler = updateStudentCommandHandler;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var result =_getStudentByIdQueryHandler.Handle(new GetStudentByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetStudent()
        {
            var result = _getStudentsQueryHandler.Handle(new GetStudentsQuery());
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentCommand command)
        {

            _createCommandHandler.Handle(command);
            return Created("",command.Name);
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveStudent(int id)
        {
            _removeStudentCommandHandler.Handle(new RemoveStudentCommand(id));
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateStudent(UpdateStudentCommand command)
        {
            _updateStudentCommandHandler.Handle(command);
            return NoContent();
        }
    }
}
