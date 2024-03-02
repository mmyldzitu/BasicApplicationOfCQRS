using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CQRSFile.Queries
{
    public class GetStudentByIdQuery
    {
        public GetStudentByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
      
    }
}
