using AutoMapper;
using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;
using BLL.Modles.Services.Interfaces;
using DataLayer.Data.Repositories.Interfaces;
using task_1.Entities;

namespace BLL.Modles.Services.Classes
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(SaveCategoryModel model)
        {
            var categoryRepository = _unitOfWork.CategoryRepository;
            var itemRepository = _unitOfWork.ItemRepository;

            var category = _mapper.Map<Category>(model);

            var existingItems = await itemRepository.GetAllAsync(x => model.Items.Contains(x.Id));
            category.Items = existingItems;

            var result = await categoryRepository.Create(category);
            await _unitOfWork.SaveChangesAsync();
            return result.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var categoryRepository = _unitOfWork.CategoryRepository;
            await categoryRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReadCategoryModel>> GetAllAsync()
        {
            var categoryRepository = _unitOfWork.CategoryRepository;
            return _mapper.Map<IEnumerable<ReadCategoryModel>>(categoryRepository.GetAll().ToList());
        }

        public async Task<ReadCategoryModel> GetByIdAsync(Guid id)
        {
            var categoryRepository = _unitOfWork.CategoryRepository;
            var category = categoryRepository.Find(id);
            return _mapper.Map<ReadCategoryModel>(category);
        }

        public async Task<Guid> UpdateAsync(UpdateCategoryModel model)
        {
            var categoryRepository = _unitOfWork.CategoryRepository;
            var category = await categoryRepository.Find(model.Id);

            _mapper.Map(model, category);

            await UpdateItems(model.Items, category);
            var result = await categoryRepository.Update(category);

            await _unitOfWork.SaveChangesAsync();

            return result.Id;
        }

        private async Task UpdateItems(List<Guid> updateItemsList, Category category)
        {
            var itemRepository = _unitOfWork.ItemRepository;
            var categoryItemIds = category.Items.Select(x => x.Id);

            var existingItems = await itemRepository.GetAllAsync(x => categoryItemIds.Contains(x.Id));

            var itemsToAdd = updateItemsList.Except(existingItems.Select(x => x.Id)).ToList();

            var itemsToRemove = existingItems.Where(x => !updateItemsList.Contains(x.Id)).ToList();

            foreach (var item in itemsToAdd)
            {
                var itemToAdd = await itemRepository.Find(item);
                category.Items.Add(itemToAdd);
            }

            foreach (var item in itemsToRemove)
            {
                category.Items.Remove(item);
            }
        }
    }
}
