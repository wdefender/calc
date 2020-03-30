using calc.Common.Infrastructure.Enums;
using calc.Common.Infrastructure.Interfaces;
using calc.Common.Infrastructure.Models;
using System;
using System.Linq;

namespace calc.Common.Services
{
    public class CalcCoreService : ICalcCoreService
    {
        private string _firstOperand;
        private string _secondOperand;
        private string _operator;

        private readonly IOutputService outputService;

        public CalcCoreService(IOutputService outputService)
        {
            this.outputService = outputService;
        }

        public void AddInput(Key key)
        {
            switch (key.Type)
            {
                case KeyType.OperatorKey:

                    if (key.Value=="=")
                    {
                        outputService.SendOutput(Calculate());
                        return;
                    }
                    _operator = key.Value;
                    outputService.SendOutput("");
                    outputService.SendOutput(_operator);
                    break;
                default:
                    if (string.IsNullOrEmpty(_operator))
                    {
                        _firstOperand = string.Concat(_firstOperand, key.Value);
                        outputService.SendOutput(_firstOperand);
                    }
                    else
                    {
                        _secondOperand = string.Concat(_secondOperand, key.Value);
                        outputService.SendOutput(_secondOperand.ToString());
                    }
                    break;
            }
        }

        private string Calculate()
        {
            if(operators.Contains(_operator))
            {
                int index = Array.IndexOf(operators, _operator);
                decimal _result = calcOps[index](Convert.ToDecimal(_firstOperand), Convert.ToDecimal(_secondOperand));
            
                _firstOperand = string.Empty;
                _secondOperand = string.Empty;
                _operator = string.Empty;
                return _result.ToString();
            }

            return "Error";
        }

        static string[] operators = { "+", "-", "*", "/" };

        // take care - it is an array of func
        // lambdas must be in the same order as operators array 
        static Func<decimal, decimal, decimal>[] calcOps = 
        { 
            (x,y) => (x + y),
            (x,y) => (x - y),
            (x,y) => (x * y),
            (x,y) => (x / y)
        };
    }
}
