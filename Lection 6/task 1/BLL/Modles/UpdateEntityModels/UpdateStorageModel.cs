namespace BLL.Modles.DeleteEntityModels;

public class UpdateStorageModel : ModelEntity
{
    public string Addres { get; set; }

    public decimal No { get; set; }

    public Guid ManagerID { get; set; }

    public List<Guid> Employees { get; set; }

    public List<Guid> Items { get; set; }
}
