using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TH3.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Name tối thiểu 4 ký tự, tối đa 100 ký tự")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$", ErrorMessage = "Địa chỉ email phải có đuôi gmail.com")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(8, ErrorMessage = "Mật khẩu từ 8 ký tự trở lên")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$",
            ErrorMessage = "Mật khẩu phải có ký tự viết hoa, viết thường, chữ số và ký tự đặc biệt")]
        public string? Password { get; set; }

        [Required]
        public Branch? Branch { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        public bool IsRegular { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string? Address { get; set; }

        [Range(typeof(DateTime), "1/1/1963", "1/1/2006")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBorth { get; set; }

        [Required(ErrorMessage = "Điểm không được để trống")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải là số thực và từ 0.0 đến 10.0")]
        public double? Score { get; set; }
    }
}
