using System.Collections.Generic;
using System.IO;

namespace Vismy.Services.Implementations
{
    public class WriterFileService : IWriterService
    {
        public string Path { get; set; }

        public void Write(string buffer)
        {
            using (var sw = File.AppendText(Path))
            {
                sw.WriteLine(buffer);
            }
        }

        public void Write(IEnumerable<string> buffer)
        {
            foreach (var buff in buffer)
            {
                Write(buff);
            }
        }

        public WriterFileService(string path) => Path = path;
    }
}