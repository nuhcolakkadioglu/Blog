using Blog.Entities.Concrete;
using Blog.Shared.Entities.Abstract;
using Blog.Shared.Utilities.Results.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Dtos.ArticleDtos
{
    public class ArticleListDto: DtoGetBase
    {
        public IList<Article> Articles { get; set; }
    }
}
