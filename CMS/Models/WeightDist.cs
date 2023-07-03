namespace CMS.Models
{
    public class WeightDist
    {
        [Key]
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [Required]
        [DisplayName("حداقل حجم")]
        public double MinWeight { get; set; } = 0;
        [Required]
        [DisplayName("حداکثر حجم")]
        public double MaxWeight { get; set; } = 0;
        [Required]
        [DisplayName("استان همجوار")]
        public double NeighboringProvince { get; set; } = 0;
        [Required]
        [DisplayName("سایر استان‌ها")]
        public double OtherProvince { get; set; } = 0;
    }
}
