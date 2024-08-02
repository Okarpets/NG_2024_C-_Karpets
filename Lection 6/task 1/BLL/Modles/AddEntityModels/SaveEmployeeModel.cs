namespace BLL.Modles.AddEntityModels
{
    public class SaveEmployeeModel
    {
        public string Name { get; set; }

        public int Phone { get; set; }

        public decimal Salary { get; set; }

        public string Position { get; set; }

        public Guid StorageID { get; set; }
    }
}
