using calc.Common.Infrastructure.Interfaces;
using calc.Common.Infrastructure.Models;
using System;

namespace calc.Common.Services
{
    public class InputService : IInputService
    {
        private readonly IOutputService outputService;

        public InputService(IOutputService outputService)
        {
            this.outputService = outputService;
        }

        public void RegisterInput(Key key)
        {
            outputService.SendOutput(key.Value);
        }
    }
}
