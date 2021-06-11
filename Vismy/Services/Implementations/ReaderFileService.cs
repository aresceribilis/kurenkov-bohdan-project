using System.IO;

namespace Vismy.Services.Implementations
{
    public class ReaderFileService : IReaderService
    {
        public string Path { get; set; }

        public string Read() => File.ReadAllText(Path);

        public ReaderFileService(string path) => Path = path;
    }
}