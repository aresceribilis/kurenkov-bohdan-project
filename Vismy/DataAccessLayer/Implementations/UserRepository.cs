using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Vismy.DataAccessLayer.Interfaces;
using Vismy.Models.Implementations;
using Vismy.Models.Interfaces;

namespace Vismy.DataAccessLayer.Implementations
{
    public class UserRepository : IUserRepository
    {
        public string ConnectionString { get; set; }

        public UserRepository(string connectionString) => ConnectionString = connectionString;

        public IEnumerable<IPerson> GetAll()
        {
            var query = "select top 10 * from Persons;";

            var result = ExecuteReader(query);

            return result;
        }

        public IPerson GetById(int id)
        {
            var query = $"select * from Persons where Persons.id = {id};";

            var result = ExecuteReader(query);

            return result.Any() ? result.First() : null;
        }

        public void Update(IPerson entity)
        {
            var query = "update Persons set " +
                        $"name = '{entity.Name}', " +
                        $"surname = '{entity.Surname}', " +
                        $"nickname = '{entity.Nickname}', " +
                        $"[password] = '{entity.Password}', " +
                        $"birthDate = '{entity.BirthDate.Date:yyyy-MM-dd}', " +
                        $"phoneNumber = '{entity.PhoneNumber}', " +
                        $"email = '{entity.Email}', " +
                        @"photoUrl = 'E:\Users\Photos\' + convert(varchar, IDENT_CURRENT('Persons')), " +
                        $"[role] = {(int) entity.Role} " +
                        $"where id = {entity.Id};";

            ExecuteNonQuery(query);
        }

        public void Delete(IPerson entity) => DeleteById(entity.Id);

        public void DeleteById(int id)
        {
            var query = $"delete from Persons where Persons.id = {id};";

            ExecuteNonQuery(query);
        }

        public void Add(IPerson entity)
        {
            var query = "insert into Persons values " +
                        $"('{entity.Name}', '{entity.Surname}', '{entity.Nickname}', '{entity.Password}', " +
                        $"'{entity.BirthDate.Date:yyyy-MM-dd}', '{entity.PhoneNumber}', '{entity.Email}', " +
                        @$"'E:\Users\Photos\' + convert(varchar, IDENT_CURRENT('Persons')), {(int) entity.Role});";

            ExecuteNonQuery(query);
        }

        private static T CreateEntity<T>(T obj, IReadOnlyList<object> objs)
        {
            var props = obj.GetType().GetProperties();

            for (var i = 0; i < objs.Count; i++)
            {
                props[i].SetValue(obj, objs[i]);
            }

            return obj;
        }

        private IEnumerable<IPerson> ExecuteReader(string query)
        {
            IEnumerable<IPerson> result;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                result = CreateEntities(query, connection);

                connection.Close();
            }

            return result;
        }

        private static IEnumerable<IPerson> CreateEntities(string query, SqlConnection connection)
        {
            var executer = new SqlCommand(query, connection).ExecuteReader();
            List<IPerson> result = new();

            if (!executer.HasRows) return result;

            while (executer.Read())
            {
                var objs = new[]
                {
                    executer.GetValue(0),
                    executer.GetValue(1),
                    executer.GetValue(2),
                    executer.GetValue(3),
                    executer.GetValue(4),
                    executer.GetValue(5),
                    executer.GetValue(6),
                    executer.GetValue(7),
                    executer.GetValue(8),
                    executer.GetValue(9),
                };

                var user = new User();
                result.Add(CreateEntity(user, objs));
            }

            return result;
        }

        private void ExecuteNonQuery(string query)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                new SqlCommand(query, connection).ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}