using CQRS.CQRSFile.Commands;
using CQRS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CQRSFile.Handlers
{
    public class RemoveStudentCommandHandler
    {
        private readonly StudentContext _studentContext;

        public RemoveStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(RemoveStudentCommand command)
        {
            var deletedEntity = _studentContext.Students.Find(command.Id);
            _studentContext.Remove(deletedEntity);
            _studentContext.SaveChanges();
        }
    }
}
