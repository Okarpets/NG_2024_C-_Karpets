using AutoMapper;
using BLL.Modles.AddEntityModels;
using BLL.Modles.DeleteEntityModels;
using BLL.Modles.GetEntityModels;
using task_1.Entities;

namespace BLL.Mapping;

public class AutoMapperBLLProfile : Profile
{
    public AutoMapperBLLProfile()
    {
        // CATEGORY

        CreateMap<Category, ReadCategoryModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description))
            .ForMember(
                dest => dest.Items,
                opt => opt.MapFrom(src => src.Items)).ReverseMap();

        CreateMap<Category, SaveCategoryModel>()
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description))
            .ForMember(
                dest => dest.Items,
                opt => opt.MapFrom(src => src.Items));

        CreateMap<Category, UpdateCategoryModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description))
            .ForMember(
                dest => dest.Items,
                opt => opt.MapFrom(src => src.Items));

        // CATEGORY END

        // CLIENT

        CreateMap<Client, ReadClientModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone));

        CreateMap<Client, SaveClientModel>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone));

        CreateMap<Client, UpdateClientModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone));

        // CLIENT END

        // EMPLOYEE

        CreateMap<Employee, ReadEmployeeModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone))
            .ForMember(
                dest => dest.Salary,
                opt => opt.MapFrom(src => src.Salary))
            .ForMember(
                dest => dest.Position,
                opt => opt.MapFrom(src => src.Position))
            .ForMember(
                dest => dest.StorageID,
                opt => opt.MapFrom(src => src.StorageID));

        CreateMap<Employee, SaveEmployeeModel>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone))
            .ForMember(
                dest => dest.Salary,
                opt => opt.MapFrom(src => src.Salary))
            .ForMember(
                dest => dest.Position,
                opt => opt.MapFrom(src => src.Position))
            .ForMember(
                dest => dest.StorageID,
                opt => opt.MapFrom(src => src.StorageID));

        CreateMap<Employee, UpdateEmployeeModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone))
            .ForMember(
                dest => dest.Salary,
                opt => opt.MapFrom(src => src.Salary))
            .ForMember(
                dest => dest.Position,
                opt => opt.MapFrom(src => src.Position))
            .ForMember(
                dest => dest.StorageID,
                opt => opt.MapFrom(src => src.StorageID));

        // EMPLOYEE END

        // ITEM

        CreateMap<Item, ReadItemModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.SenderId,
                opt => opt.MapFrom(src => src.SenderId))
            .ForMember(
                dest => dest.ReceiverId,
                opt => opt.MapFrom(src => src.ReceiverId))
            .ForMember(
                dest => dest.Weight,
                opt => opt.MapFrom(src => src.Weight))
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description))
            .ForMember(
                dest => dest.Date,
                opt => opt.MapFrom(src => src.Date))
            .ForMember(
                dest => dest.IsReceived,
                opt => opt.MapFrom(src => src.IsReceived))
            .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price))
            .ForMember(
                dest => dest.Categories,
                opt => opt.MapFrom(src => src.Categories)).ReverseMap()
            .ForMember(
                dest => dest.StorageId,
                opt => opt.MapFrom(src => src.StorageId));

        CreateMap<Item, SaveItemModel>()
            .ForMember(
                dest => dest.SenderId,
                opt => opt.MapFrom(src => src.SenderId))
            .ForMember(
                dest => dest.ReceiverId,
                opt => opt.MapFrom(src => src.ReceiverId))
            .ForMember(
                dest => dest.Weight,
                opt => opt.MapFrom(src => src.Weight))
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description))
            .ForMember(
                dest => dest.Date,
                opt => opt.MapFrom(src => src.Date))
            .ForMember(
                dest => dest.IsReceived,
                opt => opt.MapFrom(src => src.IsReceived))
            .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price))
            .ForMember(
                dest => dest.Categories,
                opt => opt.MapFrom(src => src.Categories)).ReverseMap()
            .ForMember(
                dest => dest.StorageId,
                opt => opt.MapFrom(src => src.StorageId));

        CreateMap<Item, UpdateItemModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.SenderId,
                opt => opt.MapFrom(src => src.SenderId))
            .ForMember(
                dest => dest.ReceiverId,
                opt => opt.MapFrom(src => src.ReceiverId))
            .ForMember(
                dest => dest.Weight,
                opt => opt.MapFrom(src => src.Weight))
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description))
            .ForMember(
                dest => dest.Date,
                opt => opt.MapFrom(src => src.Date))
            .ForMember(
                dest => dest.IsReceived,
                opt => opt.MapFrom(src => src.IsReceived))
            .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price))
            .ForMember(
                dest => dest.Categories,
                opt => opt.MapFrom(src => src.Categories)).ReverseMap()
            .ForMember(
                dest => dest.StorageId,
                opt => opt.MapFrom(src => src.StorageId));

        // ITEM END

        // MANAGER

        CreateMap<Manager, ReadManagerModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.StorageId,
                opt => opt.MapFrom(src => src.StorageId));

        CreateMap<Manager, SaveManagerModel>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.StorageId,
                opt => opt.MapFrom(src => src.StorageId));

        CreateMap<Manager, UpdateManagerModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.StorageId,
                opt => opt.MapFrom(src => src.StorageId));

        // MANAGER END

        // STORAGE

        CreateMap<Storage, ReadStorageModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Addres,
                opt => opt.MapFrom(src => src.Addres))
            .ForMember(
                dest => dest.No,
                opt => opt.MapFrom(src => src.No))
            .ForMember(
                dest => dest.ManagerID,
                opt => opt.MapFrom(src => src.ManagerID))
            .ForMember(
                dest => dest.Employees,
                opt => opt.MapFrom(src => src.Employees)).ReverseMap()
            .ForMember(
                dest => dest.Items,
                opt => opt.MapFrom(src => src.Items)).ReverseMap();

        CreateMap<Storage, SaveStorageModel>()
            .ForMember(
                dest => dest.Addres,
                opt => opt.MapFrom(src => src.Addres))
            .ForMember(
                dest => dest.No,
                opt => opt.MapFrom(src => src.No))
            .ForMember(
                dest => dest.ManagerID,
                opt => opt.MapFrom(src => src.ManagerID))
            .ForMember(
                dest => dest.Employees,
                opt => opt.MapFrom(src => src.Employees)).ReverseMap()
            .ForMember(
                dest => dest.Items,
                opt => opt.MapFrom(src => src.Items)).ReverseMap();

        CreateMap<Storage, UpdateStorageModel>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(
                dest => dest.Addres,
                opt => opt.MapFrom(src => src.Addres))
            .ForMember(
                dest => dest.No,
                opt => opt.MapFrom(src => src.No))
            .ForMember(
                dest => dest.ManagerID,
                opt => opt.MapFrom(src => src.ManagerID))
            .ForMember(
                dest => dest.Employees,
                opt => opt.MapFrom(src => src.Employees)).ReverseMap()
            .ForMember(
                dest => dest.Items,
                opt => opt.MapFrom(src => src.Items)).ReverseMap();

        // STORAGE END
    }
}
