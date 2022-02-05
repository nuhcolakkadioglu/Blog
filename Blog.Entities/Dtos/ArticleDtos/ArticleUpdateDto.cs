using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Dtos.ArticleDtos
{
    public class ArticleUpdateDto : ArticleAddDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Silinsin mi?")]
        [Required(ErrorMessage = "{0} Alanı boş geçilemez")]
        public bool IsDeleted { get; set; }
    }
}
