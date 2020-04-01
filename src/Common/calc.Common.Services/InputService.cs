using calc.Common.Infrastructure.Enums;
using calc.Common.Infrastructure.Interfaces;
using calc.Common.Infrastructure.Models;

namespace calc.Common.Services
{
    public class InputService : IInputService
    {
        private readonly ICalcCoreService calcCoreService;

        public InputService(ICalcCoreService calcCoreService)
        {
            this.calcCoreService = calcCoreService;
        }

        public void RegisterInput(Key key)
        {
            calcCoreService.AddInput(key);
        }
    }
}
