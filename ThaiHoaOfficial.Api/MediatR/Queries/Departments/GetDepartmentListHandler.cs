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
    public class GetDepartmentListHandler : IRequestHandler<GetDepartmentListQuery, List<Department>>
    {
        private readonly AppDbContext _context;

        public GetDepartmentListHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Departments.ToListAsync();
        }
    }
}
