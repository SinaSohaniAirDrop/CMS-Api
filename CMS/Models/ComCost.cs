namespace CMS.Models
{
    public class ComCost
    {
        [Key]
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [Required]
        [DisplayName("هزینه ثابت")]
        public double FixedCost { get; set; } = 0;
        [Required]
        [DisplayName("نرخ مالیات")]
        public double tax { get; set; } = 0;
        [Required]
        [DisplayName("هزینه مقر")]
        public string HQCost { get; set; } = string.Empty;
        [Required]
        [DisplayName("هزینه درون شهری")]
        public double InsiderFee { get; set; } = 0;
        [Required]
        [DisplayName("هزینه برون شهری")]
        public double OutsiderFee { get; set; } = 0;
    }
}
