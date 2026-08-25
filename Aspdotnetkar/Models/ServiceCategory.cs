using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aspdotnetkar.Models
{
    public class ServiceCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری میباشد")]
        [DisplayName("نام گروه خدمات")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string ServiceCategoryTitle { get; set; }


        public ICollection<SiteService> siteservices { get; set; }
    }
}
