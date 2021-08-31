using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.Enums;

namespace ThaiHoaOfficial.Shared.CommandModels
{
    public class CreateOrUpdateDepartmentModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nội dung là bắt buộc")]
        [MaxLength(50, ErrorMessage = "Nội dung phải ít hơn 50 ký tự")]
        public string Name { get; set; }
        public DepartmentStatus Status { get; set; }
        public string Notification { get; set; }

    }
}
