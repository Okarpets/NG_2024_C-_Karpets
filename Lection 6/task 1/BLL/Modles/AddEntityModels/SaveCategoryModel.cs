namespace BLL.Modles.AddEntityModels
{
    public class SaveCategoryModel
    {
        public string Description { get; set; }

        public ICollection<Guid> Items { get; set; }
    }
}
