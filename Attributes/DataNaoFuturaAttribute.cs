using System.ComponentModel.DataAnnotations;

namespace InvestmentControl.Attributes
{
    public class DataNaoFuturaAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateValue)
            {
                return dateValue <= DateTime.Today;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} não pode ser uma data futura";
        }
    }
}
