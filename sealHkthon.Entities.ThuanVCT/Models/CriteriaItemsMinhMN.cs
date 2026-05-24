using System.ComponentModel.DataAnnotations;

namespace sealHkthon.Entities.MinhMN.Models
{
    public partial class CriteriaItemsMinhMN
    {
        public long CriteriaIdMinhMN { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn bộ template.")]
        [Display(Name = "Bộ template")]
        public long? CriteriaSetIdMinhMN { get; set; }

        [Required(ErrorMessage = "Tên tiêu chí không được để trống.")]
        [StringLength(250)]
        [Display(Name = "Tên tiêu chí")]
        public string CriteriaName { get; set; } = string.Empty;

        [StringLength(1000)]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "100", ErrorMessage = "Trọng số từ 0 đến 100.")]
        [Display(Name = "Trọng số (%)")]
        public decimal Weight { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "999999", ErrorMessage = "Điểm tối đa phải >= 0.")]
        [Display(Name = "Điểm tối đa")]
        public decimal MaxScore { get; set; }

        public virtual CriteriaTemplateSetsMinhMN? CriteriaTemplateSetsMinhMN { get; set; }
    }
}
