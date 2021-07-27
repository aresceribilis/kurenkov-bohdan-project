using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Vismy.Core.Interfaces;

namespace Vismy.Application.Services
{
    public class WriterFileService : IWriterService
    {
        public string Path { get; set; }
        public WriterFileService(string path) => Path = path;

        public async Task WriteAsync(string buffer)
        {
            await using var sw = File.AppendText(Path);
            await sw.WriteLineAsync(buffer);
        }

        public async Task WriteAsync(IEnumerable<string> buffer)
        {
            foreach (var buff in buffer)
            {
                await WriteAsync(buff);
            }
        }
    }
}