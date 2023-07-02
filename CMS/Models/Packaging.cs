namespace CMS.Models
{
    public class Packaging
    {
        [Key]
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [Required]
        [DisplayName("نام")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DisplayName("حداقل طول/عرض/ارتفاع")]
        public double MinL { get; set; } = 0;
        [Required]
        [DisplayName("حداکثر طول/عرض/ارتفاع")]
        public double MaxL { get; set; } = 0;
        [Required]
        [DisplayName("هزینه بسته‌بندی")]
        public double PackagingCost { get; set; } = 0;
    }
}
