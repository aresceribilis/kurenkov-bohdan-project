using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Vismy.Models.Implementations;
using Vismy.Services.Interfaces;

namespace Vismy.Services.Implementations
{
    public class SerializationJsonUserService : ISerializationJsonService<User>
    {
        public IValidatorService<User> Validator { get; set; }
        public string Serialize(User obj) => Validator.Validate(obj) ? JsonConvert.SerializeObject(obj) : string.Empty;
        public IEnumerable<string> Serialize(List<User> objs) => objs.Select(Serialize);
        public IEnumerable<User> Deserialize(string buff)
        {
            List<User> objs = new();

            if (buff == string.Empty)
                return objs;

            foreach (var meta in buff.TrimEnd().Split("\r\n"))
            {
                objs.Add(JsonConvert.DeserializeObject<User>(meta));
            }

            return objs.Where(Validator.Validate);
        }

        public SerializationJsonUserService(IValidatorService<User> validator)
        {
            Validator = validator;
        }
    }
}