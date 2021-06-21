using System.Collections.Generic;

namespace Vismy.Services.Implementations
{
    public interface IWriterService
    {
        public string Path { get; set; }

        public void Write(IEnumerable<string> buffer);
    }
}