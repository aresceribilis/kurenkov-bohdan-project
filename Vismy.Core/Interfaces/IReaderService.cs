using System.Threading.Tasks;

namespace Vismy.Core.Interfaces
{
    public interface IReaderService
    {
        public string Path { get; set; }

        public Task<string> ReadAsync();
    }
}