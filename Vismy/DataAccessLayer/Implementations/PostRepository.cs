using System.Collections.Generic;
using Vismy.DataAccessLayer.Interfaces;
using Vismy.Models;

namespace Vismy.DataAccessLayer.Implementations
{
    public class PostRepository : IPostRepository
    {
        public IEnumerable<Post> GetAll()
        {
            return DatabaseMock.Posts;
        }

        public Post GetById(int id)
        {
            return DatabaseMock.Posts.Find(p => p.Id == id);
        }

        public void Update(Post entity)
        {
            Delete(GetById(entity.Id));
            Add(entity);
        }

        public void Delete(Post entity)
        {
            DatabaseMock.Posts.Remove(entity);
        }

        public void DeleteById(int id)
        {
            Delete(GetById(id));
        }

        public void Add(Post entity)
        {
            DatabaseMock.Posts.Add(entity);
        }
    }
}