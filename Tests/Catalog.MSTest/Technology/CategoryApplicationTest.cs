using Catalog.Application.Dtos.Category.Request;
using Catalog.Application.Interfaces;
using Catalog.Utilities.Static;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.MSTest.Technology
{
    [TestClass]
    public class CategoryApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task CreateTechnology_WhenSendingNullOrEmptpy_ValidationErrors()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope?.ServiceProvider.GetService<ITechnologyApplication>();

            //  
            var name = "";
            var version = "";
            var description = "";
            var expected = ReplyMessage.MESSAGE_VALIDATE;

            //Act
            var result = await context.CreateTechnology(new TechnologyRequestDto()
            {
                Name = name,
                Version = version,
                Description = description
            });
            var current = result.Message;

            //Assert
            Assert.AreEqual(expected, current);
        }

        [TestMethod]
        public async Task CreateTechnology_WhenSendCorrectValues_CreatedSuccessfully()
        {

            using var scope = _scopeFactory!.CreateScope();
            var context = scope?.ServiceProvider.GetService<ITechnologyApplication>();

            //  
            var name = "Assembly";
            var version = "1.0";
            var description = "Assembler";
            var expected = ReplyMessage.MESSAGE_CREATE;

            //Act
            var result = await context.CreateTechnology(new TechnologyRequestDto()
            {
                Name = name,
                Version = version,
                Description = description
            });
            var current = result.Message;

            //Assert
            Assert.AreEqual(expected, current);
        }
    }
}
