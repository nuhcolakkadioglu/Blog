using AutoMapper;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos.CategoryDtos;
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
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var article = await _unitOfWork.Categories.GetAsync(m => m.Id == categoryId, m => m.Articles);

            if (article != null)
            {

                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = article,
                    ResultStatus = ResultStatus.Success
                });

            }

            return new DataResult<CategoryDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı", null);

        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var data = await _unitOfWork.Categories.GetAllAsync(null, m => m.Articles);
            if (data.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = data,
                    ResultStatus = ResultStatus.Success,
                    Message = "kayıt bulunamadı"
                });

            }

            return new DataResult<CategoryListDto>(ResultStatus.Error, "kayıt bulunamadı", new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "kayıt bulunamadı"
            });

        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDelete()
        {
            var data = await _unitOfWork.Categories.GetAllAsync(m => !m.IsDeleted, m => m.Articles);
            if (data.Count > -1)
            {

                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = data,
                    ResultStatus = ResultStatus.Success
                });

            }

            return new DataResult<CategoryListDto>(ResultStatus.Error, "kayıt bulunamadı", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleteAndActive()
        {
            var data = await _unitOfWork.Categories.GetAllAsync(m => !m.IsDeleted && m.IsActive, m => m.Articles);
            if (data.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = data,
                    ResultStatus = ResultStatus.Success
                });

            }

            return new DataResult<CategoryListDto>(ResultStatus.Error, "kayıt bulunamadı", null);
        }


        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(m => m.Id == categoryId);
            if (category is not null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{category.Name} adlı kategori kalıcı olarak silindi");

            }
            return new Result(ResultStatus.Error, "kayıt bulunamadı");

        }
        public async Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(m => m.Id == categoryId);
            if (category is not null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;

                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{category.Name} adlı kategori silindi");
            }
            return new Result(ResultStatus.Error, "kayıt bulunamadı");
        }

        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;

            var addDto = await _unitOfWork.Categories.AddAsync(category);

            await _unitOfWork.SaveAsync();

            return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryAddDto.Name} Başarı ile eklenmiştir.", new CategoryDto
            {
                Category = addDto,
                Message = $"{categoryAddDto.Name} Başarı ile eklenmiştir.",
                ResultStatus = ResultStatus.Success
            });
        }


        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryAddDto, string modifiedByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.ModifiedByName = modifiedByName;

            var updateDto = await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryAddDto.Name} adlı kategori güncellenmiştir", new CategoryDto
            {
                Category = updateDto,
                Message = $"{categoryAddDto.Name} adlı kategori güncellenmiştir",
                ResultStatus = ResultStatus.Success
            });

        }

    }
}
