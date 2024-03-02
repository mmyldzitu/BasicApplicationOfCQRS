using CQRS.CQRSFile.Commands;
using CQRS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CQRSFile.Handlers
{
    public class UpdateStudentCommandHandler
    {
        private readonly StudentContext _studentContext;

        public UpdateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(UpdateStudentCommand command)
        {
            var updatedEntity=_studentContext.Students.Find(command.Id);
            updatedEntity.Age = command.Age;
            updatedEntity.Name = command.Name;
            updatedEntity.Surname = command.Surname;
            _studentContext.SaveChanges();
        }
    }
}
