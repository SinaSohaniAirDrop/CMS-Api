namespace CMS.Models
{
    public class Insurance
    {
        [Key]
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [Required]
        [DisplayName("حداقل ارزش بسته")]
        public double MinVal { get; set; } = 0;
        [Required]
        [DisplayName("حداکثر ارزش بسته")]
        public double MaxVal { get; set; } = 0;
        [Required]
        [DisplayName("تعرفه بیمه")]
        public double Tariff { get; set; } = 0;
    }
}
