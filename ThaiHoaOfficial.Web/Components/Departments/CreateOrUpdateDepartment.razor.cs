using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.Models;

namespace ThaiHoaOfficial.Web.Components.Departments
{
    public class CreateOrUpdateDepartmentBase:ComponentBase
    {
        public bool visible { get; set; }
        public Department Department { get; set; }
        public async Task ShowDialog(Department department)
        {
            Department = department;
            visible = true;
        }
    }
}
