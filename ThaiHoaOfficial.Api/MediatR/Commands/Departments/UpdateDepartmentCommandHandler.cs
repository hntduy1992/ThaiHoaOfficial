using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ThaiHoaOfficial.Api.Data;
using ThaiHoaOfficial.Shared.Models;

namespace ThaiHoaOfficial.Api.MediatR.Commands.Departments
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateDepartmentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department department = _context.Departments.Find(request.updateDepartment.Id);
            if (department == null) return false;
            department.Name = request.updateDepartment.Name;
            department.Notification = request.updateDepartment.Notification;
            department.Status = request.updateDepartment.Status;

            _context.Departments.Update(department);
            return (await _context.SaveChangesAsync())>0;
        }
    }
}
