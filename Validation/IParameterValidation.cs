using BluePrismTechnicalTest.DTO;

namespace BluePrismTechnicalTest.Validation
{
    public interface IParameterValidation<T>
    {
        ValidationResult IsValid(T parameter);
    }
}