using System.Collections.Generic;
using Vismy.DataAccessLayer.Interfaces;
using Vismy.Models.Interfaces;

namespace Vismy.DataAccessLayer.Implementations
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<IPerson> GetAll()
        {
            return DatabaseMock.Users;
        }

        public IPerson GetById(int id)
        {
            return DatabaseMock.Users.Find(u => u.Id == id);
        }

        public void Update(IPerson entity)
        {
            Delete(GetById(entity.Id));
            Add(entity);
        }

        public void Delete(IPerson entity)
        {
            DatabaseMock.Users.Remove(entity);
        }

        public void DeleteById(int id)
        {
            Delete(GetById(id));
        }

        public void Add(IPerson entity)
        {
            DatabaseMock.Users.Add(entity);
        }
    }
}