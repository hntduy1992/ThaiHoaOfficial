using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.Enums;
using ThaiHoaOfficial.Shared.Models;

namespace ThaiHoaOfficial.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid firstGuid = Guid.NewGuid();
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = firstGuid, Name = "Administrator", Status = DepartmentStatus.Hidden, CreatedDate = DateTime.Now },
                new Department { Id = Guid.NewGuid(), Name = "Phòng CNTT", Status = DepartmentStatus.Unconfirmed, CreatedDate = DateTime.Now }
                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    FullName = "Hồ Ngọc Tư Duy",
                    Status = UserStatus.Activited,
                    CreatedDate = DateTime.Now,
                    DepartmentId = firstGuid,
                    DateOfBirth = DateTime.Parse("20/05/1992"),
                    EmailAddress = "hntduy1992@gmail.com",
                    PhoneNumber = "0939433628",
                    IsMale = true
                }
                );
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
