using NSubstitute;
using task_1.Entities;
using Xunit;

namespace task_1.Tests.Entities
{
    public class CategoryTests
    {
        [Fact]
        public void CategoryCorrectly()
        {
            // Arrange
            var category = new Category();

            var id = Guid.NewGuid();
            var description = "Default";
            var items = new List<Item>
            {
                new Item { Id = Guid.NewGuid() },
                new Item { Id = Guid.NewGuid() }
            };

            var newItem = new Item { Id = Guid.NewGuid() };

            // Act
            category.Items.Add(newItem);

            category.Id = id;
            category.Items = items;
            category.Description = description;

            // Assert
            Assert.Null(category.Id);
            Assert.Equal(id, category.Id);

            Assert.Null(category.Items);
            Assert.Equal(items, category.Items);

            Assert.Null(category.Description);
            Assert.Equal(description, category.Description);

            Assert.Null(category.Items);
            Assert.Contains(newItem, category.Items);
            Assert.Equal(3, category.Items.Count);
        }

        [Fact]
        public void ClientCorrectly()
        {
            // Arrange
            var client = new Client();

            var id = Guid.NewGuid();
            var name = "Default";
            var phone = "Default";

            client.Phone = phone;
            client.Name = name;

            // Act

            client.Phone = phone;
            client.Name = name;

            // Assert
            Assert.Null(client.Id);
            Assert.Equal(id, client.Id);

            Assert.Null(client.Phone);
            Assert.Equal(phone, client.Phone);

            Assert.Null(client.Name);
            Assert.Equal(name, client.Name);
        }

        [Fact]
        public void EmployeeCorrectly()
        {
            // Arrange
            var employee = new Employee();

            var id = Guid.NewGuid();
            var name = "Default";
            var phone = 1;
            var salary = 1;
            var position = "Defalut";
            var storageId = Guid.NewGuid();
            var storage = Substitute.For<Storage>();

            // Act
            employee.Id = id;
            employee.Name = name;
            employee.Phone = phone;
            employee.Salary = salary;
            employee.Position = position;
            employee.StorageID = storageId;
            employee.Storage = storage;

            // Assert
            Assert.Null(employee.Id);
            Assert.Equal(id, employee.Id);

            Assert.Null(employee.Name);
            Assert.Equal(name, employee.Name);

            Assert.Null(employee.Phone);
            Assert.Equal(phone, employee.Phone);

            Assert.Null(employee.Salary);
            Assert.Equal(salary, employee.Salary);

            Assert.Null(employee.Position);
            Assert.Equal(position, employee.Position);

            Assert.Null(employee.StorageID);
            Assert.Equal(storageId, employee.StorageID);

            Assert.Null(employee.Storage);
            Assert.Equal(storage, employee.Storage);
        }

        [Fact]
        public void ItemCorrectly()
        {
            // Arrange
            var item = new Item();

            var id = Guid.NewGuid();
            var senderId = Guid.NewGuid();
            var receiverId = Guid.NewGuid();
            var weight = 1;
            var description = "Defalut";
            var price = 1;
            var isReceived = true;
            var date = DateTime.Now;
            var storageId = Guid.NewGuid();
            var storage = Substitute.For<Storage>();
            var categories = new List<Category>()
            {
                new Category { Id = Guid.NewGuid() },
                new Category { Id = Guid.NewGuid() }
            };

            var newCategories = new Category { Id = Guid.NewGuid() };

            // Act
            item.Id = id;
            item.SenderId = senderId;
            item.ReceiverId = receiverId;
            item.Weight = weight;
            item.Description = description;
            item.Price = price;
            item.IsReceived = isReceived;
            item.Date = date;
            item.StorageId = storageId;
            item.Storage = storage;
            item.Categories = categories;

            item.Categories.Add(newCategories);

            // Assert
            Assert.Null(item.Id);
            Assert.Equal(id, item.Id);

            Assert.Null(item.SenderId);
            Assert.Equal(senderId, item.Id);

            Assert.Null(item.ReceiverId);
            Assert.Equal(receiverId, item.Id);

            Assert.Null(item.Weight);
            Assert.Equal(weight, item.Weight);

            Assert.Null(item.Description);
            Assert.Equal(description, item.Description);

            Assert.Null(item.Price);
            Assert.Equal(price, item.Price);

            Assert.Null(item.IsReceived);
            Assert.Equal(isReceived, item.IsReceived);

            Assert.Null(item.Date);
            Assert.Equal(date, item.Date);

            Assert.Null(item.StorageId);
            Assert.Equal(storageId, item.StorageId);

            Assert.Null(item.Storage);
            Assert.Equal(storage, item.Storage);

            Assert.Null(item.Categories);
            Assert.Contains(newCategories, item.Categories);
            Assert.Equal(3, item.Categories.Count);
        }

        [Fact]
        public void ManagerCorrectly()
        {
            // Arrange
            var manager = new Manager();

            var id = Guid.NewGuid();
            var name = "Default";
            var storageId = Guid.NewGuid();
            var storage = Substitute.For<Storage>();

            // Act
            manager.Id = id;
            manager.Name = name;
            manager.StorageId = storageId;
            manager.Storage = storage;

            // Assert
            Assert.Null(manager.Id);
            Assert.Equal(id, manager.Id);

            Assert.Null(manager.Name);
            Assert.Equal(name, manager.Name);

            Assert.Null(manager.StorageId);
            Assert.Equal(storageId, manager.StorageId);

            Assert.Null(manager.Storage);
            Assert.Equal(storage, manager.Storage);
        }

        [Fact]
        public void StorageCorrectly()
        {
            // Arrange
            var storage = new Storage();

            var id = Guid.NewGuid();
            var address = "Default";
            var no = 1;
            var managerId = Guid.NewGuid();
            var manager = Substitute.For<Manager>();
            var employees = new List<Employee>()
            {
                new Employee { Id = Guid.NewGuid() },
                new Employee { Id = Guid.NewGuid() }
            };

            var newEmployee = new Employee { Id = Guid.NewGuid() };

            var items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid() },
                new Item { Id = Guid.NewGuid() }
            };

            var newItem = new Item { Id = Guid.NewGuid() };

            // Act
            storage.Id = id;
            storage.Addres = address;
            storage.No = no;
            storage.ManagerID = managerId;
            storage.Manager = manager;
            storage.Employees = employees;
            storage.Items = items;

            storage.Employees.Add(newEmployee);
            storage.Items.Add(newItem);

            // Assert
            Assert.Null(storage.Id);
            Assert.Equal(id, storage.Id);

            Assert.Null(storage.Addres);
            Assert.Equal(address, storage.Addres);

            Assert.Null(storage.No);
            Assert.Equal(no, storage.No);

            Assert.Null(storage.ManagerID);
            Assert.Equal(managerId, storage.ManagerID);

            Assert.Null(storage.Manager);
            Assert.Equal(manager, storage.Manager);

            Assert.Null(storage.Employees);
            Assert.Contains(newEmployee, storage.Employees);
            Assert.Equal(3, storage.Employees.Count);

            Assert.Null(storage.Items);
            Assert.Contains(newItem, storage.Items);
            Assert.Equal(3, storage.Items.Count);
        }
    }
}