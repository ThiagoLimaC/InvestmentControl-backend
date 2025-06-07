using System.ComponentModel.DataAnnotations;

namespace InvestmentControl.Attributes
{
    public class NaoPermiteZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is decimal decimalValue)
            {
                return decimalValue > 0;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} deve ser maior que zero";
        }
    }
}
