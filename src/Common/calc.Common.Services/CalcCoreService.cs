using calc.Common.Infrastructure.Enums;
using calc.Common.Infrastructure.Interfaces;
using calc.Common.Infrastructure.Models;
using System;

namespace calc.Common.Services
{
    public class CalcCoreService : ICalcCoreService
    {
        private string x_register;
        private string y_register;
        private string flag_register;

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
                        flag_register = "=";
                        outputService.SendOutput(x_register);
                        return;
                    }

                    if (key.Value== "+/-")
                    {
                        if (x_register == "0") return;
                        
                        x_register = x_register[0].ToString() == "-".ToString() ? x_register.Remove(0, 1) : string.Concat("-", x_register);
                        outputService.SendOutput(x_register);
                        return;
                    }

                    if (key.Value == "sqrt")
                    {
                        x_register = BigFloat.Parse(x_register).Sqrt().ToString();
                        outputService.SendOutput(x_register);
                        return;
                    }

                    if (key.Value == "1/x")
                    {

                        x_register =  (new BigFloat(1) / BigFloat.Parse(x_register)).ToString();
                        outputService.SendOutput(x_register);
                        return;
                    }

                    flag_register = key.Value;
                    outputService.SendOutput("");
                    outputService.SendOutput(flag_register);

                    break;
                case KeyType.MemoryKey:
                    if (key.Value=="C")
                    {
                        x_register = string.Empty;
                        y_register = string.Empty;
                        flag_register = string.Empty;
                        outputService.SendOutput("0");
                    }
                    break;
                default:
                    if (string.IsNullOrEmpty(flag_register))
                    {
                        x_register = string.Concat(x_register, key.Value);
                        outputService.SendOutput(x_register);
                    }
                    else
                    {
                        if (flag_register == "=")
                        {
                            y_register = x_register;
                            flag_register = string.Empty;
                            outputService.SendOutput(x_register);
                        }
                        else if (string.IsNullOrEmpty(y_register))
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
