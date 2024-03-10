using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.Shared
{
    public static class CpfValidator
    {
        public static bool IsValid(string cpf)
        {

            if (string.IsNullOrWhiteSpace(cpf))
            {
                return false;
            }

            if (cpf.Length != 11)
            {
                return false;
            }

            if (cpf.All(digit => digit == cpf[0]))
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int remainder = sum % 11;
            int firstDigit = remainder < 2 ? 0 : 11 - remainder;

            if (int.Parse(cpf[9].ToString()) != firstDigit)
            {
                return false;
            }

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            remainder = sum % 11;
            int secondDigit = remainder < 2 ? 0 : 11 - remainder;

            if (int.Parse(cpf[10].ToString()) != secondDigit)
            {
                return false;
            }

            return true;
        }
    }
}
