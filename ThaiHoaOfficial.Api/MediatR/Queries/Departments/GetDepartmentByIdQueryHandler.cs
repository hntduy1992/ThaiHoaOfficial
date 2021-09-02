using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ThaiHoaOfficial.Api.Data;
using ThaiHoaOfficial.Shared.Models;

namespace ThaiHoaOfficial.Api.MediatR.Queries.Departments
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Department>
    {
        private readonly AppDbContext _context;
        

        public GetDepartmentByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Department> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Departments.FindAsync(request.Id);
        }
    }
}
