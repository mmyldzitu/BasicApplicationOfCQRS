using CQRS.CQRSFile.Queries;
using CQRS.CQRSFile.Results;
using CQRS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CQRSFile.Handlers
{
    public class GetStudentsQueryHandler
    {
        private readonly StudentContext _studentContext;

        public GetStudentsQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery query)
        {
           var students= _studentContext.Students.Select(x=> new GetStudentsQueryResult {Name=x.Name, Surname=x.Surname, Age=x.Age, Id=x.Id }).AsNoTracking().AsEnumerable();
            return students;
        }
    }
}
