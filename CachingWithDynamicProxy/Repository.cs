using System.Collections.Generic;
using System.Linq;
using CachingWithDynamicProxy.DTOs;

namespace CachingWithDynamicProxy
{
    public class Repository : IRepository
    {
        private readonly List<Person> _inMemoryList;

        public Repository()
        {
            _inMemoryList = new List<Person>
                {
                    new Person { Id = 1, Name = "Alex" }, 
                    new Person { Id = 2, Name = "Thomas" }
                };
        }

        public Person GetById(int id)
        {
            return _inMemoryList.FirstOrDefault(x => x.Id == id);
        }

        public Person GetBySpecification(ByIdSpecification byIdSpecification)
        {
            return _inMemoryList.FirstOrDefault(x => x.Id == byIdSpecification.Id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _inMemoryList;
        }
    }
}