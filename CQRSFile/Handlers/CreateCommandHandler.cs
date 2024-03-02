using CQRS.CQRSFile.Commands;
using CQRS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CQRSFile.Handlers
{
    public class CreateCommandHandler
    {
        private readonly StudentContext _studentContext;

        public CreateCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        public void Handle(CreateStudentCommand command)
        {
            _studentContext.Students.Add(new Student { Age = command.Age, Name = command.Name, Surname = command.Surname });
            _studentContext.SaveChanges();
        }
    }
}
