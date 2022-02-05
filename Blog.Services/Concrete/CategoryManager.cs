using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos;
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

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            await _unitOfWork.Categories.AddAsync(new Category
            {
                Name = categoryAddDto.Name,
                Description = categoryAddDto.Description,
                Note = categoryAddDto.Note,
                IsActive = categoryAddDto.IsActive,
                CreatedByName = createdByName,
                CreatedDate = DateTime.Now,
                ModifiedByName = createdByName,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            });

            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{categoryAddDto.Name} Başarı ile eklenmiştir.");
        }



        public async Task<IDataResult<Category>> Get(int categoryId)
        {
            var data = await _unitOfWork.Categories.GetAsync(m => m.Id == categoryId, m => m.Articles);
            if (data != null)
                return new DataResult<Category>(ResultStatus.Success, data);

            return new DataResult<Category>(ResultStatus.Error, "Böyle bir kategori bulunamadı", null);

        }

        public async Task<IDataResult<IList<Category>>> GetAll()
        {
            var data = await _unitOfWork.Categories.GetAllAsync(null, m => m.Articles);
            if (data.Count > -1)
                return new DataResult<IList<Category>>(ResultStatus.Success, data);

            return new DataResult<IList<Category>>(ResultStatus.Error, "kayıt bulunamadı", null);

        }

        public async Task<IDataResult<IList<Category>>> GetAllByNonDelete()
        {
            var data = await _unitOfWork.Categories.GetAllAsync(m => !m.IsDeleted, m => m.Articles);
            if (data.Count > -1)
                return new DataResult<IList<Category>>(ResultStatus.Success, data);

            return new DataResult<IList<Category>>(ResultStatus.Error, "kayıt bulunamadı", null);
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(m => m.Id == categoryId);
            if (category is not null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{category.Name} adlı kategori silindi");

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

        public async Task<IResult> Update(CategoryUpdateDto categoryAddDto, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(m => m.Id == categoryAddDto.Id);
            if (category is not null)
            {
                category.Name = categoryAddDto.Name;
                category.Description = categoryAddDto.Description;
                category.Note = categoryAddDto.Note;
                category.IsActive = categoryAddDto.IsActive;
                category.IsDeleted = categoryAddDto.IsDeleted;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;

                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{categoryAddDto.Name} adlı kategori güncellenmiştir");
            }
            return new Result(ResultStatus.Error, "kayıt bulunamadı");

        }
    }
}
