using CQRS.CQRSFile.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CQRSFile.Queries
{
    public class GetStudentsQuery:IRequest<IEnumerable<GetStudentsQueryResult>>
    {
    }
}
