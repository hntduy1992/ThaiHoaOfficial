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
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, bool>
    {
        private readonly AppDbContext _context;

        public CreateDepartmentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Guid newGuid = Guid.NewGuid();
            while (_context.Departments.Any(x => x.Id == newGuid))
            {
                newGuid = Guid.NewGuid();
            }
            Department department = new Department()
            {
                Id = newGuid,
                Name = request.NewDepartment.Name,
                Notification = request.NewDepartment.Notification,
                CreatedDate = DateTime.Now.Date,
                Status = request.NewDepartment.Status,
            };
            _context.Departments.Add(department);
            
            return (await _context.SaveChangesAsync())>0;
        }
    }
}
