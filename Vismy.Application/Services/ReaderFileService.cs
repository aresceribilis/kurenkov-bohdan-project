using System.IO;
using System.Threading.Tasks;
using Vismy.Core.Interfaces;

namespace Vismy.Application.Services
{
    public class ReaderFileService : IReaderService
    {
        public string Path { get; set; }
        public ReaderFileService(string path) => Path = path;

        public async Task<string> ReadAsync() => await File.ReadAllTextAsync(Path);
    }
}