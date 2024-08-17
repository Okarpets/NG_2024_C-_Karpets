namespace BLL.Modles.GetEntityModels
{
    public class ReadStorageModel : ModelEntity
    {
        public string Addres { get; set; }

        public decimal No { get; set; }

        public Guid ManagerID { get; set; }

        public List<ReadEmployeeModel> Employees { get; set; }

        public List<ReadItemModel> Items { get; set; }
    }
}
