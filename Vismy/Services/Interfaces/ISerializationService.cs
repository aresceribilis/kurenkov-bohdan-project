using System.Collections.Generic;

namespace Vismy.Services.Interfaces
{
    public interface ISerializationService<T>
    {
        public string Serialize(T obj);
        public IEnumerable<T> Deserialize(string buff);
    }
}