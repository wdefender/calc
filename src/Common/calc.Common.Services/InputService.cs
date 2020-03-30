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
            switch (key.Type)
            {
                case KeyType.OperatorKey:
                    calcCoreService.AddInput(key);
                    break;
                default:
                    calcCoreService.AddInput(key);
                    break;
            }
        }
    }
}
