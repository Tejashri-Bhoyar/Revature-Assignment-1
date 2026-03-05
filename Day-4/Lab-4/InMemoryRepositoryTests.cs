using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Core;
using Infrastructure;
using System.Linq;

namespace Tests
{
    public class InMemoryRepositoryTests
    {
        private readonly IRepository<User> _repository;

        public InMemoryRepositoryTests()
        {
            var services = new ServiceCollection();

            // DI setup (Transient avoids shared state)
            services.AddTransient<IRepository<User>, InMemoryRepository<User>>();

            var provider = services.BuildServiceProvider();
            _repository = provider.GetRequiredService<IRepository<User>>();
        }

        [Fact]
        public void Add_ShouldStoreItem()
        {
            var user = new User { Id = 1, Name = "Alice" };

            _repository.Add(user);

            var result = _repository.GetById(1);

            Assert.NotNull(result);
            Assert.Equal("Alice", result.Name);
        }

        [Fact]
        public void Remove_ShouldDeleteItem()
        {
            var user = new User { Id = 2, Name = "Bob" };
            _repository.Add(user);

            _repository.Remove(2);

            Assert.Null(_repository.GetById(2));
        }

        [Fact]
        public void GetAll_ShouldReturnAllItems()
        {
            _repository.Add(new User { Id = 3, Name = "A" });
            _repository.Add(new User { Id = 4, Name = "B" });

            var users = _repository.GetAll();

            Assert.Equal(2, users.Count());
        }
    }
}
