namespace CMS.Models
{
    public class User
    {
        [Key]
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [Required]
        [DisplayName("نام و نام خانوادگی")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DisplayName("ایمیل")]
        public string Email { get; set; } = string.Empty;
        [DisplayName("شماره تماس")]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [DisplayName("رمز عبور")]
        public string Password { get; set; } = string.Empty;
        [DisplayName("آدرس")]
        public string Address { get; set; } = string.Empty;
        [DisplayName("تایید شده")]
        public bool IsConfirmed { get; set; } = false;
        [DisplayName("ادمین")]
        public bool IsAdmin { get; set; } = false;
    }
}
