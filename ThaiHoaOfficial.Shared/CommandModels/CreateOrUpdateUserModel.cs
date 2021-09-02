using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.Enums;

namespace ThaiHoaOfficial.Shared.CommandModels
{
   public  class CreateOrUpdateUserModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nội dung là bắt buộc")]
        [MaxLength(50, ErrorMessage = "Nội dung phải ít hơn 50 ký tự")]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsMale { get; set; }
        [Required(ErrorMessage = "Nội dung là bắt buộc")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Nội dung là bắt buộc")]
        public string EmailAddress { get; set; }
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",ErrorMessage = "Nội dung phải có ít nhất 8 ký tự, có chữ và số")]
        //public string Password { get; set; }
        [Required(ErrorMessage = "Nội dung là bắt buộc")]
        public Guid DepartmentId { get; set; }
    }
}
