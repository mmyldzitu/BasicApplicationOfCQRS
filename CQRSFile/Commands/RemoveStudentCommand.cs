﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CQRSFile.Commands
{
    public class RemoveStudentCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveStudentCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
