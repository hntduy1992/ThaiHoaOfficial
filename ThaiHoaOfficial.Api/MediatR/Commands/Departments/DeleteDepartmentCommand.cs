using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThaiHoaOfficial.Api.MediatR.Commands.Departments
{
    public record DeleteDepartmentCommand(Guid Id) : IRequest<bool>;
  
}
