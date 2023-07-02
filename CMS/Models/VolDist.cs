namespace CMS.Models
{
    public class VolDist
    {
        [Key]
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [Required]
        [DisplayName("حداقل حجم")]
        public double MinVol { get; set; } = 0;
        [Required]
        [DisplayName("حداکثر حجم")]
        public double MaxVol { get; set; } = 0;
        [Required]
        [DisplayName("استان همجوار")]
        public double NeighboringProvince { get; set; } = 0;
        [Required]
        [DisplayName("سایر استان‌ها")]
        public double OtherProvince { get; set; } = 0;
    }
}
