using System.Collections.Generic;
using CachingWithDynamicProxy.DTOs;

namespace CachingWithDynamicProxy
{
    public interface IRepository
    {
        Person GetById(int id);
        IEnumerable<Person> GetAll();
        Person GetBySpecification(ByIdSpecification byIdSpecification);
    }
}