namespace Vismy.Services.Interfaces
{
    public interface ISerializationJsonService<T> : ISerializationService<T>
    {
        public IValidatorService<T> Validator { get; set; }
    }
}