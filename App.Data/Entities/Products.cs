using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data
{
    [Table("Product")]
    public class Products : BaseEntity
    {
        [Required(ErrorMessage = "Ürün ismi boş geçilemez!"), MaxLength(50, ErrorMessage = "50 karakteri geçemez!")]
        public string Name { get; set; }
        public int CategoriesId { get; set; }
        public virtual Categories Categories { get; set; }
    }
}
