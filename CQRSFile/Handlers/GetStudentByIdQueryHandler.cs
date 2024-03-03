using CQRS.CQRSFile.Queries;
using CQRS.CQRSFile.Results;
using CQRS.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.CQRSFile.Handlers
{
    public class GetStudentByIdQueryHandler:IRequestHandler<GetStudentByIdQuery,GetStudentByIdQueryResult>
    {
        private readonly StudentContext _studentContext;

        public GetStudentByIdQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async  Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentContext.Set<Student>().FindAsync(request.Id);
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
