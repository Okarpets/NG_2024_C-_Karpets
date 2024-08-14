using DataLayer.Data.Repositories.Interfaces;
using task_1.Entities;

namespace DataLayer
{
    public class DataSeeder
    {
        private readonly IUnitOfWork _uof;

        public DataSeeder(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public async Task Seed()
        {
            var repository = _uof.StorageRepository;

            var storages = new List<Storage>();
            {
                new Storage
                {
                    Id = Guid.NewGuid(),
                    ManagerID = Guid.NewGuid(),
                    No = -1,
                    Addres = "Default",
                };
            }

            foreach (var storage in storages)
            {
                await repository.Create(storage);
            }

            await _uof.SaveChangesAsync();
        }
    }
}
