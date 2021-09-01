using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.Models;
using ThaiHoaOfficial.Shared.ViewModels;

namespace ThaiHoaOfficial.Shared.Modules
{
   public static class ConvertModel
    {
        public static UserViewModel UserConvert(User user)
        {
            UserViewModel result = new UserViewModel()
            {
                Id = user.Id,
                FullName = user.FullName,
                DateOfBirth = user.DateOfBirth,
                CreatedDate = user.CreatedDate,
                IsMale = user.IsMale,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.EmailAddress,
                Status = user.Status,
                DepartmentName = user.Department != null ? user.Department.Name : ""
            };
            return result;
        }
    }
}
