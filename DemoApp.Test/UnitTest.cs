using System;
using DemoApp.Domain;
using DemoApp.Services.Repositories;
using DemoApp.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoApp.Test
{
    [TestClass]
    public class UnitTest
    {
        private TestService _testService;
        private FakePackageRepository _fakePackRepo;


        [TestInitialize]
        public void Initialize()
        {

            _fakePackRepo = new FakePackageRepository();
            _testService = new TestService(_fakePackRepo);

        }

        [TestMethod]
        public void Not_Possible_without_Ordercode()
        {
            var order = new Order();
            order.Package = _fakePackRepo.GetSinglePackage(3);
            var result = _testService.AddOrder(order);

            Assert.IsTrue(result);
        }
    }
}
