using Blog.Data.Abstract;
using Blog.Entities.Dtos.ArticleDtos;
using Blog.Services.Abstract;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.ComplexType;
using Blog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int articleId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(m=>m.Id==articleId,m=>m.User,m=>m.Category);
            if (article is not null)
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto { 
                Article = article,
                ResultStatus = ResultStatus.Success
                });

            return   new DataResult<ArticleDto>(ResultStatus.Error,"Kayıt bulunamadı",null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var article = await _unitOfWork.Articles.GetAllAsync(null, m => m.User, m => m.Category); 
            if (article.Count > -1)
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = article,
                    ResultStatus = ResultStatus.Success
                });

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Kayıt bulunamadı", null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var category = await _unitOfWork.Categories.AnyAsync(m => m.Id == categoryId);

            if(category==false)
                return new DataResult<ArticleListDto>(ResultStatus.Error, "kategori bulunamadı", null);


            var article = await _unitOfWork.Articles.GetAllAsync(m => m.CategoryId==categoryId && m.IsActive && !m.IsDeleted, m => m.User, m => m.Category);

            if (article.Count > -1)
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = article,
                    ResultStatus = ResultStatus.Success
                });

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Kayıt bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDelete()
        {
            var article = await _unitOfWork.Articles.GetAllAsync(m=>!m.IsDeleted, m => m.User, m => m.Category);
            if (article.Count > -1)
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = article,
                    ResultStatus = ResultStatus.Success
                });

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Kayıt bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleteAndActive()
        {
            var article = await _unitOfWork.Articles.GetAllAsync(m => !m.IsDeleted && m.IsActive, m => m.User, m => m.Category);
            if (article.Count > -1)
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = article,
                    ResultStatus = ResultStatus.Success
                });

            return new DataResult<ArticleListDto>(ResultStatus.Error, "Kayıt bulunamadı", null);
        }

        public Task<IResult> HardDelete(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
