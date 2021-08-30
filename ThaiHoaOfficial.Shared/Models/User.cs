using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.Enums;

namespace ThaiHoaOfficial.Shared.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
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
        public DateTime CreatedDate { get; set; }
        public UserStatus Status { get; set; }
        
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
