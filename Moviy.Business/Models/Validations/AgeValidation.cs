namespace Moviy.Business.Models.Validations
{
    public class AgeValidation
    {
        public static bool IsOfAge(DateTime birthDate)
        {
            var age = DateTime.Now.Year - birthDate.Year;

            if (birthDate.Date > DateTime.Now.AddYears(-age))
                age--;

            if (age >= 18)
                return true;
            return false;
        }
    }
}
