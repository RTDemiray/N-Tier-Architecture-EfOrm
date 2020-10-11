using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data
{
    [Table("Category")]
    public class Categories : BaseEntity
    {
        [Required(ErrorMessage = "Kategori ismi boş geçilemez!"),MaxLength(50,ErrorMessage = "50 karakteri geçemez!")]
        public string Name { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
