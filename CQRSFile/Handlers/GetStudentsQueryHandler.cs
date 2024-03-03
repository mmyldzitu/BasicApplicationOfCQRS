using CQRS.CQRSFile.Queries;
using CQRS.CQRSFile.Results;
using CQRS.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.CQRSFile.Handlers
{
    public class GetStudentsQueryHandler:IRequestHandler<GetStudentsQuery,IEnumerable<GetStudentsQueryResult>>
    {
        private readonly StudentContext _studentContext;

        public GetStudentsQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
       

        public async  Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await  _studentContext.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname, Age = x.Age, Id = x.Id }).AsNoTracking().ToListAsync();
            return students;
        }
    }
}
