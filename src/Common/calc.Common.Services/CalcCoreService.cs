using calc.Common.Infrastructure.Enums;
using calc.Common.Infrastructure.Interfaces;
using calc.Common.Infrastructure.Models;
using System;

namespace calc.Common.Services
{
    public class CalcCoreService : ICalcCoreService
    {
        private string x_register = string.Empty;
        private string y_register = string.Empty;
        private string flag_register = string.Empty;

        private readonly IOutputService outputService;

        public CalcCoreService(IOutputService outputService)
        {
            this.outputService = outputService;
            outputService.SendOutput("0");
        }

        public void ProcesInput(Key key)
        { 
            switch (key.Type)
            {
                case KeyType.MemoryKey:
                    procesMemoryKey(key);
                    break;
                case KeyType.NumericKey:
                    procesNumericKey(key);
                    break;
                case KeyType.OperatorKey:
                    procesOperatorKey(key);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void procesOperatorKey(Key key)
        {
            if (key.Value == "+/-")
            {
                if (string.IsNullOrEmpty(x_register) || x_register == "0") return;
                x_register = x_register[0].ToString() == "-".ToString() ? x_register.Remove(0, 1) : string.Concat("-", x_register);
                outputService.SendOutput(x_register);
                return;
            }
            else if (key.Value == "=")
            {
                if (string.IsNullOrEmpty(x_register) || string.IsNullOrEmpty(y_register)) return;
                x_register = ComputeResult();
                y_register = string.Empty;

            }
            else if (key.Value == "sqrt")
            {
                if (string.IsNullOrEmpty(x_register) || x_register == "0") return;
                x_register = BigFloat.Parse(x_register).Sqrt().ToString();
            }
            else if (key.Value == "1/x")
            {
                if (string.IsNullOrEmpty(x_register) || x_register == "0") return;
                x_register = (new BigFloat(1) / BigFloat.Parse(x_register)).ToString();
            }
            else if  (key.Value == "%")
            {
                if (string.IsNullOrEmpty(x_register) || x_register == "0") return;
                x_register = (BigFloat.Parse(x_register) / new BigFloat(100)).ToString();
            }
            else
            {
                flag_register = key.Value;
                y_register = x_register;
                x_register = string.Empty;
                outputService.SendOutput("");
                outputService.SendOutput(flag_register);
                return;
            }

            flag_register = "=";
            outputService.SendOutput(x_register);
        }

        private void procesNumericKey(Key key)
        {
            if (key.Value == ",")
            {
                if (flag_register == "=")
                {
                    x_register = "0,";
                    flag_register = string.Empty;
                }
                else if (x_register.Contains(','))
                {
                    return;
                }
                else
                {
                    x_register = string.IsNullOrEmpty(x_register)
                                        ? "0,"
                                        : string.Concat(x_register, key.Value);
                }
            }
            else if (string.IsNullOrEmpty(flag_register))
            {
                x_register = string.Concat(x_register, key.Value);
            }
            else
            {
                if (flag_register == "=")
                {
                    x_register = key.Value;
                    flag_register = string.Empty;
                }
                else
                {
                    x_register = string.Concat(x_register, key.Value);
                }
            }

            outputService.SendOutput(x_register);
        }

        private void procesMemoryKey(Key key)
        {
            switch (key.Value)
            {
                case "C":
                    x_register = string.Empty;
                    y_register = string.Empty;
                    flag_register = string.Empty;
                    break;
               
                default:
                    throw new NotImplementedException();
            }

            outputService.SendOutput("0");
        }
    

        private string ComputeResult()
        {
            int index = Array.IndexOf(operators, flag_register);
            BigFloat _resultBF = ALU_Ops[index](BigFloat.Parse(x_register), BigFloat.Parse(y_register));
            return _resultBF.ToString();
        }

        static string[] operators = { "+", "-", "*", "/" };

        // take care - it is an array of func
        // lambdas must be in the same order as operators array 
        static Func<BigFloat, BigFloat, BigFloat>[] ALU_Ops =
        {
            (x,y) => y + x,
            (x,y) => y - x,
            (x,y) => y * x,
            (x,y) => y / x,
        };
    }
}
