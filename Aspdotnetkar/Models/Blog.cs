using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aspdotnetkar.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "این فیلد اجباری میباشد")]
        [DisplayName("عنوان بلاگ")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string BlogTitle { get; set; }


        [Required(ErrorMessage = "این فیلد اجباری میباشد")]
        [DisplayName("توضیح مختصر")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(300,ErrorMessage ="بیش از 300 کاراکتر ممکن نیست")]
        [DataType(DataType.MultilineText)]
        public string BlogShortdescription { get; set; }



        [Required(ErrorMessage = "این فیلد اجباری میباشد")]
        [DisplayName("متن بلاگ")]
        [Column(TypeName = "nvarchar")]
        [MaxLength()]
        [DataType(DataType.MultilineText)]
        public string BlogText { get; set; }



        [Required(ErrorMessage = "این فیلد اجباری میباشد")]
        [DisplayName("تاریخ ایجاد بلاگ")]
        [DataType(DataType.DateTime)]
        public string BlogCreateDate { get; set; }


       
        [DisplayName("عکس")]
        public string BlogImage { get; set; }

        [DisplayName("هشتگ")]
        public string Tags { get; set; }


        [DisplayName("تعداد بازدید")]
        public int BlogVisitCount { get; set; }



        [ForeignKey(nameof(BlogCategory))]
        public int BlogsId { get; set; }

        public BlogCategory BlogCategories { get; set; }
    }
}
