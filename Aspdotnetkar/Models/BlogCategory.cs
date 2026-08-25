using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aspdotnetkar.Models
{
    public class BlogCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری میباشد")]
        [DisplayName("نام گروه بندی بلاگ")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string BlogCategoryTitle { get; set; }

        public ICollection<Blog> blogs { get; set; }
    }
}
