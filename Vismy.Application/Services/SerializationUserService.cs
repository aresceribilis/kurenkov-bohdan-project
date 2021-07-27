using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Vismy.Core.Interfaces;

namespace Vismy.Application.Services
{
    //public class SerializationUserService : ISerializationService<User>
    //{
    //    //public IValidatorService<User> Validator { get; set; }

    //    public SerializationUserService(IValidatorService<User> validator)
    //    {
    //        Validator = validator;
    //    }

    //    public string SerializeAsync(User obj) => Validator.Validate(obj) ? JsonConvert.SerializeObject(obj) : string.Empty;
    //    public IEnumerable<string> SerializeAsync(List<User> objs) => objs.Select(Serialize);
    //    public IEnumerable<User> DeserializeAsync(string buff)
    //    {
    //        List<User> objs = new();

    //        if (buff == string.Empty)
    //            return objs;

    //        foreach (var meta in buff.TrimEnd().Split("\r\n"))
    //        {
    //            objs.Add(JsonConvert.DeserializeObject<User>(meta));
    //        }

    //        return objs.Where(Validator.Validate);
    //    }
    //}
}