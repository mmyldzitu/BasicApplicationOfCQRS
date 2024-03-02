using CQRS.CQRSFile.Queries;
using CQRS.CQRSFile.Results;
using CQRS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CQRSFile.Handlers
{
    public class GetStudentByIdQueryHandler
    {
        private readonly StudentContext _studentContext;

        public GetStudentByIdQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
        {
            var student =_studentContext.Set<Student>().Find(query.Id);
            return new GetStudentByIdQueryResult
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age
            };
        }
    }
}
