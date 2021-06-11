namespace Vismy.Services.Interfaces
{
    public interface IValidatorService<T>
    {
        public bool Validate(T obj);
    }
}