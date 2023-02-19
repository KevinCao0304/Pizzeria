using MockQueryable.Moq;
using Moq;
using PizzeriaApi.Data;
using PizzeriaApi.DTO;
using PizzeriaApi.Models;
using PizzeriaApi.Repository;
using PizzeriaApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PizzeriaApiTest
{

    public class StoreRepositoryTest : IClassFixture<TestDatabaseFixture>
    {
        private readonly Mock<IRepositoryWrapper> _mock;
        public StoreRepositoryTest(TestDatabaseFixture fixture)
        {
            Fixture = fixture;
            _mock = new Mock<IRepositoryWrapper>();
        }


        public TestDatabaseFixture Fixture { get; }


        private IQueryable<Store> GetStoreData()
        {
            List<Store> productsData = new List<Store>
            {
                new Store
                {
                    Id = 1,
                    StoreName = "Store1",
                    Location = "Mel1"
                },
                 new Store
                {
                    Id = 2,
                    StoreName = "Store2",
                    Location = "Mel2"
                }
            };
            return productsData.AsQueryable();
        }

        private IQueryable<Store> GetStoreDataId(int id)
        {
            List<Store> productsData = new List<Store>
            {
                new Store
                {
                    Id = 1,
                    StoreName = "Store1",
                    Location = "Mel1"
                },
                 new Store
                {
                    Id = 2,
                    StoreName = "Store2",
                    Location = "Mel2"
                }
            };
            return productsData.Where(x => x.Id == id).AsQueryable().BuildMock();
        }

        [Fact]
        public async void GetStoreList()
        {
            //arrange
            var storeList = GetStoreData();
            _mock.Setup(x => x.Store.GetAll())
                .Returns(storeList);
            var storeRepository = new StoreRepository(_mock.Object);
            //act
            var storeResult = await storeRepository.GetStoreList();

            //assert
            Assert.NotNull(storeResult);
            Assert.Equal(storeList.ToList()[0].StoreName, storeResult[0].StoreName);
        }

        [Theory]
        [InlineData(1)]
        public async void GetStore(int id)
        {
            //arrange
            var store = GetStoreDataId(id);

            _mock.Setup(x => x.Store.GetBy(x => x.Id == id)).Returns(store);

            var storeRepository = new StoreRepository(_mock.Object);
            //act
            var storeResult = await storeRepository.GetStore(id);

            //assert
            Assert.NotNull(storeResult);
            Assert.Equal(store.ToList()[0].StoreName, storeResult.StoreName);
        }

        [Fact]
        public async void SaveStore()
        {
            var context = Fixture.CreateContext();
            context.Database.BeginTransaction();
            _mock.Setup(x => x.Store).Returns(new RepositoryBase<Store>(context));
            var storeRepository = new StoreRepository(_mock.Object);
            var result= await storeRepository.SaveStore(new StoreDTO() { Id = 1, Location = "333", StoreName = "333" });
            Assert.Equal(1, result.ResponseKey);
            context.Database.RollbackTransaction();
        }

        [Fact]
        public async void DeleteStore()
        {
            var context = Fixture.CreateContext();
            context.Database.BeginTransaction();
            _mock.Setup(x => x.Store).Returns(new RepositoryBase<Store>(context));
            var storeRepository = new StoreRepository(_mock.Object);
            var result = await storeRepository.DeleteStore(1);
            var expected = await storeRepository.GetStore(1);
            Assert.Equal(null, expected);
            context.Database.RollbackTransaction();
        }

    }
}
