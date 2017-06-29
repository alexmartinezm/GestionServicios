using GestionServicios.Core.IOC;
using GestionServicios.Domain.DataContext;
using GestionServicios.Droid.Sqlite;
using NUnit.Framework;
using Xamarin.Forms;

namespace GestionServiciosUnitTest.Tests
{
    [TestFixture]
    public class SqliteTest
    {
        [SetUp]
        public void SetUp()
        {
            DependencyService.Register<ISqlite>();
            DependencyService.Register<SqliteDroid>();
            DependencyService.Register<SqliteDataContext>();
        }

        [Test]
        public void ConnectionTest()
        {
            var context = Global.GetInstance().Context;

            Assert.IsNotNull(context);
            Assert.IsNotNull(context.Database.DataBasePath);
        }
    }
}