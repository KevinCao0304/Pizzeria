using Microsoft.EntityFrameworkCore;
using PizzeriaApi.Data;

namespace PizzeriaApiTest
{
    #region TestDatabaseFixture
    public class TestDatabaseFixture
    {
        private const string ConnectionString = @"SERVER=DESKTOP-DPU7MDF\SQLEXPRESS;database=Pizzeria;Persist Security Info=True;Trusted_Connection=Yes;MultipleActiveResultSets=True";

        private static readonly object _lock = new();
        //private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            //lock (_lock)
            //{
            //    if (!_databaseInitialized)
            //    {
            //        using (var context = CreateContext())
            //        {
            //            context.Database.EnsureDeleted();
            //            context.Database.EnsureCreated();
            //            context.AddRange(
            //            new Blog { Name = "Blog1", Url = "http://blog1.com" },
            //                new Blog { Name = "Blog2", Url = "http://blog2.com" });
            //            context.SaveChanges();
            //        }

            //        _databaseInitialized = true;
            //    }
            //}
        }

        public PizzeriaDbContext CreateContext()
            => new PizzeriaDbContext(
                new DbContextOptionsBuilder<PizzeriaDbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
    }
    #endregion
}
