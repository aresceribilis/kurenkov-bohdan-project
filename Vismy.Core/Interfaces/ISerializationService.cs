using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vismy.Core.Interfaces
{
    public interface ISerializationService<T>
    {
        //public IValidatorService<T> Validator { get; set; }
        
        public Task<string> SerializeAsync(T obj);
        public Task<IEnumerable<T>> DeserializeAsync(string buff);
    }
}