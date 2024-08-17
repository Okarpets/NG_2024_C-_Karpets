namespace BLL.Modles.DeleteEntityModels;

public class UpdateCategoryModel : ModelEntity
{
    public string Description { get; set; }

    public List<Guid> Items { get; set; }
}
