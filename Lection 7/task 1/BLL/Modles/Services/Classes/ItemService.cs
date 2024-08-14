using AutoMapper;
using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;
using BLL.Modles.Services.Interfaces;
using DataLayer.Data.Repositories.Interfaces;
using task_1.Entities;

namespace BLL.Modles.Services.Classes
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(SaveItemModel model)
        {
            var itemRepository = _unitOfWork.ItemRepository;

            var item = _mapper.Map<Item>(model);

            var result = await itemRepository.Create(item);
            await _unitOfWork.SaveChangesAsync();
            return result.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var itemRepository = _unitOfWork.ItemRepository;
            await itemRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReadItemModel>> GetAllAsync()
        {
            var itemRepository = _unitOfWork.ItemRepository;
            return _mapper.Map<IEnumerable<ReadItemModel>>(itemRepository.GetAll().ToList());
        }

        public async Task<ReadItemModel> GetByIdAsync(Guid id)
        {
            var itemRepository = _unitOfWork.ItemRepository;
            var item = itemRepository.Find(id);
            return _mapper.Map<ReadItemModel>(item);
        }

        public async Task<IEnumerable<ReadItemModel>> GetBySender(Guid id)
        {
            var itemRepository = _unitOfWork.ItemRepository;
            var item = itemRepository.GetAllAsync(x => x.SenderId == id);
            return _mapper.Map<IEnumerable<ReadItemModel>>(item);
        }

        public async Task<IEnumerable<ReadItemModel>> GetByReceiver(Guid id)
        {
            var itemRepository = _unitOfWork.ItemRepository;
            var item = itemRepository.GetAllAsync(x => x.ReceiverId == id);
            return _mapper.Map<IEnumerable<ReadItemModel>>(item);
        }

        public async Task<IEnumerable<ReadItemModel>> GetByStorage(Guid id)
        {
            var itemRepository = _unitOfWork.ItemRepository;
            var item = itemRepository.GetAllAsync(x => x.StorageId == id);
            return _mapper.Map<IEnumerable<ReadItemModel>>(item);
        }

        public async Task<IEnumerable<ReadItemModel>> GetItemsByParams(List<decimal> weights, string description, List<DateTime> dates, List<ReadCategoryModel> categories)
        {
            var categoryIds = categories.Select(c => c.Id).ToList();

            var itemRepository = _unitOfWork.ItemRepository;
            var items = await itemRepository.GetAllAsync(
                x => x.Description == description &&
                     x.Date >= dates[0] && x.Date <= dates[1] &&
                     x.Weight >= weights[0] && x.Weight <= weights[1] &&
                     x.Categories.Any(c => categoryIds.Contains(c.Id))
            );

            return _mapper.Map<IEnumerable<ReadItemModel>>(items);
        }

        public async Task<Guid> UpdateAsync(UpdateItemModel model)
        {
            var itemRepository = _unitOfWork.ItemRepository;
            var item = await itemRepository.Find(model.Id);

            _mapper.Map(model, item);

            var result = await itemRepository.Update(item);

            await _unitOfWork.SaveChangesAsync();

            return result.Id;
        }

        public async Task<Guid> UpdateItemStatus(UpdateItemModel model)
        {
            var itemRepository = _unitOfWork.ItemRepository;
            var item = await itemRepository.Find(model.Id);
            item.IsReceived = !item.IsReceived;

            _mapper.Map(model, item);

            var result = await itemRepository.Update(item);

            await _unitOfWork.SaveChangesAsync();

            return result.Id;
        }
    }
}

