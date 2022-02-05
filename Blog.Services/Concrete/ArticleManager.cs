using AutoMapper;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
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
        private readonly IMapper _mapper;
        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            //TODO: burayı düzenle
            article.UserId = 1;
            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale eklendi");

        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(m => m.Id == articleId, m => m.User, m => m.Category);
            if (article is not null)
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success
                });

            return new DataResult<ArticleDto>(ResultStatus.Error, "Kayıt bulunamadı", null);

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

            if (category == false)
                return new DataResult<ArticleListDto>(ResultStatus.Error, "kategori bulunamadı", null);


            var article = await _unitOfWork.Articles.GetAllAsync(m => m.CategoryId == categoryId && m.IsActive && !m.IsDeleted, m => m.User, m => m.Category);

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
            var article = await _unitOfWork.Articles.GetAllAsync(m => !m.IsDeleted, m => m.User, m => m.Category);
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

        public async Task<IResult> HardDelete(int articleId)
        {
            var articleIsExist = await _unitOfWork.Articles.AnyAsync(m => m.Id == articleId);
            if (articleIsExist == false)
                return new Result(ResultStatus.Error, "Makale bulunamadı");

            var article = await _unitOfWork.Articles.GetAsync(m => m.Id == articleId);
            await _unitOfWork.Articles.DeleteAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale kalıcı olarak Silin di");

        }
        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var articleIsExist = await _unitOfWork.Articles.AnyAsync(m => m.Id == articleId);
            if (articleIsExist == false)
                return new Result(ResultStatus.Error, "Makale bulunamadı");

            var article = await _unitOfWork.Articles.GetAsync(m => m.Id == articleId);
            article.IsDeleted = true;
            article.ModifiedByName = modifiedByName;
            article.ModifiedDate = DateTime.Now;

            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale Silin di");


        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;
            await _unitOfWork.Articles.UpdateAsync(article);
            return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} Başlıklı makale başarı ile güncellendi");
        }
    }
}
