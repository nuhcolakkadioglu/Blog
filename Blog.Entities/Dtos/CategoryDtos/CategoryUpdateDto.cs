using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Dtos.CategoryDtos
{
    public class CategoryUpdateDto : CategoryAddDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Silindi mi?")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        public bool IsDeleted { get; set; }

    }
}
