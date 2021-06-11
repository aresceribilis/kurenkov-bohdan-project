namespace Vismy.Services.Implementations
{
    public interface IReaderService
    {
        public string Path { get; set; }

        public string Read();
    }
}