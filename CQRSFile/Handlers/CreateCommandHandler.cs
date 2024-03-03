using CQRS.CQRSFile.Commands;
using CQRS.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.CQRSFile.Handlers
{
    public class CreateCommandHandler:IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public CreateCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
       

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            await _studentContext.Students.AddAsync(new Student { Age = request.Age, Name = request.Name, Surname = request.Surname });
            await _studentContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
