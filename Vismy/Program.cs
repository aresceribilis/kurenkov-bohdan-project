using System;
using System.Configuration;
using System.Data.SqlClient;
using Vismy.DataAccessLayer.Implementations;
using Vismy.Models.Enums;
using Vismy.Models.Implementations;

namespace Vismy
{
    class Program
    {
        public static void Main()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var userRepository = new UserRepository(connectionString);

            var ronald = new User()
            {
                Nickname = "Ronald123",
                Password = "123Abc",
                BirthDate = DateTime.Now,
                Email = "Ron123@gmail.com",
                Name = "Ronald",
                Surname = "Arny",
                PhoneNumber = "0990334498",
                Role = PersonRole.User
            };

            try
            {
                connection.Open();
                Console.WriteLine("Successfull");

                userRepository.DeleteById(39);

                userRepository.Add(ronald);

                var sergey = userRepository.GetById(1);
                Console.WriteLine("User1:");
                Console.WriteLine(sergey);
                Console.WriteLine();

                var users = userRepository.GetAll();
                Console.WriteLine("Users:");
                foreach (var person in users)
                {
                    Console.WriteLine(person);
                }
                Console.WriteLine();

                sergey.Nickname = "rooooooow123";
                userRepository.Update(sergey);

                Console.WriteLine("User1 local:");
                Console.WriteLine(sergey);
                Console.WriteLine();

                users = userRepository.GetAll();
                Console.WriteLine("Users:");
                foreach (var person in users)
                {
                    Console.WriteLine(person);
                }
                Console.WriteLine();

                sergey.Nickname = "strelok";
                userRepository.Update(sergey);

                users = userRepository.GetAll();
                Console.WriteLine("Users:");
                foreach (var person in users)
                {
                    Console.WriteLine(person);
                }
                Console.WriteLine();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Done");
            }

            //var path = @"E:\GitHub\kurenkov-bohdan-project\Vismy\DataAccessLayer\Users.txt";
            //var fw = new WriterFileService(path);
            //var fr = new ReaderFileService(path);
            //var serializatorUser = new SerializationJsonUserService(new ValidatorUserService());

            //var user = new User("Ronald123", "123Abc")
            //{
            //    BirthDate = DateTime.Now,
            //    Email = "Ron123@gmail.com",
            //    Id = 5,
            //    Name = "Ronald",
            //    Surname = "Arny",
            //    PhoneNumber = "0990334498"
            //};

            //fw.Write(serializatorUser.Serialize(user));
            //fw.Write(serializatorUser.Serialize(user));

            //var users = new List<User>();
            //users.Add(user);
            //users.Add(user);
            //users.Add(user);

            //fw.Write(serializatorUser.Serialize(users));

            //serializatorUser.
            //    Deserialize(fr.Read()).
            //    ToList().
            //    ForEach(Console.WriteLine);
        }
    }
}