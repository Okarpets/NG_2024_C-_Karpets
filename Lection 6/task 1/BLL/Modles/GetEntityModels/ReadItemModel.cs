using BLL.Modles.AddEntityModels;

namespace BLL.Modles.GetEntityModels;

public class ReadItemModel : ModelEntity
{
    public Guid SenderId { get; set; }

    public Guid ReceiverId { get; set; }

    public decimal Weight { get; set; }

    public string Description { get; set; }

    public DateTime Date { get; set; }

    public bool IsReceived { get; set; }

    public decimal Price { get; set; }

    public Guid StorageId { get; set; }

    public List<SaveCategoryModel> Categories { get; set; }
}
