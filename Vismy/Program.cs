using System;
using System.Collections.Generic;
using System.Linq;
using Vismy.Models.Implementations;
using Vismy.Services.Implementations;

namespace Vismy
{
    class Program
    {
        public static void Main()
        {
            var path = @"E:\GitHub\kurenkov-bohdan-project\Vismy\DataAccessLayer\Users.txt";
            var fw = new WriterFileService(path);
            var fr = new ReaderFileService(path);
            var serializatorUser = new SerializationJsonUserService(new ValidatorUserService());

            var user = new User("Ronald123", "123Abc")
            {
                BirthDate = DateTime.Now,
                Email = "Ron123@gmail.com",
                Id = 5,
                Name = "Ronald",
                Surname = "Arny",
                PhoneNumber = "0990334498"
            };

            fw.Write(serializatorUser.Serialize(user));
            fw.Write(serializatorUser.Serialize(user));

            var users = new List<User>();
            users.Add(user);
            users.Add(user);
            users.Add(user);

            fw.Write(serializatorUser.Serialize(users));

            serializatorUser.
                Deserialize(fr.Read()).
                ToList().
                ForEach(Console.WriteLine);
        }
    }
}