using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vismy.Core.Interfaces
{
    public interface IWriterService
    {
        public string Path { get; set; }

        public Task WriteAsync(IEnumerable<string> buffer);
    }
}