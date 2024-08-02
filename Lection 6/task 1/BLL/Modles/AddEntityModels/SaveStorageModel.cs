namespace BLL.Modles.AddEntityModels
{
    public class SaveStorageModel
    {
        public string Addres { get; set; }

        public decimal No { get; set; }

        public Guid ManagerID { get; set; }

        public ICollection<Guid> Employees { get; set; }

        public ICollection<Guid> Items { get; set; }
    }
}
