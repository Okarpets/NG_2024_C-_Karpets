namespace BLL.Modles.GetEntityModels
{
    public class ReadCategoryModel : ModelEntity
    {
        public string Description { get; set; }

        public List<ReadItemModel> Items { get; set; }
    }
}
