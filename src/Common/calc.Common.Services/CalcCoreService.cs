using calc.Common.Infrastructure.Enums;
using calc.Common.Infrastructure.Interfaces;
using calc.Common.Infrastructure.Models;
using System;
using System.Numerics;

namespace calc.Common.Services
{
    public class CalcCoreService : ICalcCoreService
    {
        private string x_register;
        private string y_register;
        private string flag_Register;

        private readonly IOutputService outputService;

        public CalcCoreService(IOutputService outputService)
        {
            this.outputService = outputService;
            outputService.SendOutput("0");
        }

        public void AddInput(Key key)
        {

            switch (key.Type)
            {
                case KeyType.OperatorKey:

                    if (key.Value=="=")
                    {
                        x_register = Calculate();
                        y_register = string.Empty;
                        flag_Register = "=";
                        outputService.SendOutput(x_register);
                        return;
                    }

                    flag_Register = key.Value;
                    outputService.SendOutput("");
                    outputService.SendOutput(flag_Register);

                    break;
                default:
                    if (string.IsNullOrEmpty(flag_Register))
                    {
                        x_register = string.Concat(x_register, key.Value);
                        outputService.SendOutput(x_register);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(y_register) || (flag_Register == "="))
                        {
                            y_register = x_register;
                            x_register = key.Value;
                            outputService.SendOutput(x_register);
                        }
                        else
                        {
                            x_register = string.Concat(x_register, key.Value);
                            outputService.SendOutput(x_register);
                        }
                    }
                    break;
            }
        }

        private string Calculate()
        {

                int index = Array.IndexOf(operators, flag_Register);
                //BigInteger _result = bigCalcOps[index](BigInteger.Parse(_firstOperand), BigInteger.Parse(_secondOperand));

                BigFloat _resultBF = bigFloatOps[index](BigFloat.Parse(x_register), BigFloat.Parse(y_register));
                
                return _resultBF.ToString();

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

        static Func<BigInteger, BigInteger, BigInteger>[] bigCalcOps =
        {
            (x,y) => (x + y),
            (x,y) => (x - y),
            (x,y) => (x * y),
            (x,y) => (x / y)
        };

        static Func<BigFloat, BigFloat, BigFloat>[] bigFloatOps =
        {
            (x,y) => (y + x),
            (x,y) => (y - x),
            (x,y) => (y * x),
            (x,y) => (y / x)
        };
    }
}
