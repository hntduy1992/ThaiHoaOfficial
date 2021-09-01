using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.Models;

namespace ThaiHoaOfficial.Api.MediatR.Queries.Departments
{
    public record GetDepartmentByIdQuery(Guid Id) : IRequest<Department>;
    
}
