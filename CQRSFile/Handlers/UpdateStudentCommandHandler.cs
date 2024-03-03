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
    public class UpdateStudentCommandHandler:IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public UpdateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

       

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updatedEntity = await _studentContext.Students.FindAsync(request.Id);
            updatedEntity.Age = request.Age;
            updatedEntity.Name = request.Name;
            updatedEntity.Surname = request.Surname;
            await _studentContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
