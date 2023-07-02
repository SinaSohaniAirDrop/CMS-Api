namespace CMS.Models
{
    public class Province
    {
        [Key]
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [Required]
        [DisplayName("نام استان")]
        public string Name { get; set; } = string.Empty;
        [ForeignKey("Province")]
        [DisplayName("استان همجوار")]
        public int? NeighboringProvinceId { get; set; }
        public Province? NeighboringProvince { get; set; }
    }
}
