using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ThaiHoaOfficial.Api.Data;

namespace ThaiHoaOfficial.Api.MediatR.Commands.Departments
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteDepartmentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _context.Departments.Find(request.Id);
            if (department == null) return false;
            _context.Departments.Remove(department);
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
