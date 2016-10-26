using DemoApp.Domain;
using DemoApp.Services.Repositories;

namespace DemoApp.Services.Services
{
    public class TestService : ITestService
    {

        private readonly IStartRepository _startRepository;

        public TestService(IStartRepository startRepository)
        {
            _startRepository = startRepository;
        }

        public bool AddOrder(Order order)
        {
            var pack = _startRepository.GetSinglePackage(order.Package.Id);
            if (pack.Name != "Car") return false;
            return true;
        }
    }
}
