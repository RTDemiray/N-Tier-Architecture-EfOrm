using System;
using System.ComponentModel.DataAnnotations;

namespace App.Data
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedOn = DateTime.Now;
            IsActive = false;
            RowGuid = Guid.NewGuid();
        }

        [Key]
        public int Id { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
