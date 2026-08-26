using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aspdotnetkar.Models
{
    public class SiteService
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "این فیلد اجباری میباشد")]
        [DisplayName("عنوان خدمات")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string ServiceTitle { get; set; }


        [Required(ErrorMessage = "این فیلد اجباری میباشد")]
        [DisplayName("توضیح مختصر")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(300, ErrorMessage = "بیش از 300 کاراکتر ممکن نیست")]
        [DataType(DataType.MultilineText)]
        public string ServiceShortdescription { get; set; }



        [Required(ErrorMessage = "این فیلد اجباری میباشد")]
        [DisplayName("متن خدمات")]
        [Column(TypeName = "nvarchar")]
        [MaxLength()]
        [DataType(DataType.MultilineText)]
        public string ServiceText { get; set; }



        [DisplayName("عکس")]
        public string ServiceImage { get; set; }


        [DisplayName("هشتگ")]
        public string Tags { get; set; }

       


        public int SiteServiceId { get; set; }
        [ForeignKey("SiteServiceId")]
        public ServiceCategory serviceCategory { get; set; }

    }
}
