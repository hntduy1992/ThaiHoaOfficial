using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.Enums;

namespace ThaiHoaOfficial.Shared.ViewModels
{
   public  class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsMale { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserStatus Status { get; set; }
        public string DepartmentName { get; set; }
    }
}
