using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class User
    {
        [Key]
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [DisplayName("نام و نام خانوادگی")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("ایمیل")]
        public string Email { get; set; } = string.Empty;
        [DisplayName("شماره تماس")]
        public string Phone { get; set; } = string.Empty;
        [DisplayName("رمز عبور")]
        public string Password { get; set; } = string.Empty;
        [DisplayName("آدرس")]
        public string Address { get; set; } = string.Empty;
    }
}
