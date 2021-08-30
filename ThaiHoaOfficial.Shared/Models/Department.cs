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
    [Table("Departments")]
    public class Department
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nội dung là bắt buộc")]
        [MaxLength(50, ErrorMessage ="Nội dung phải ít hơn 50 ký tự")]
        public string Name { get; set; }
        public string Notification { get; set; }
        public DepartmentStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
    }
}
