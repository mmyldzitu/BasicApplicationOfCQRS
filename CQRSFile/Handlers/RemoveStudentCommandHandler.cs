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
    public class RemoveStudentCommandHandler:IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public RemoveStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _studentContext.Students.FindAsync(request.Id);
            _studentContext.Remove(deletedEntity);
            await _studentContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
