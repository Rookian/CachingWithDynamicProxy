using System.Collections.Generic;
using CachingWithDynamicProxy.DTOs;

namespace CachingWithDynamicProxy
{
    public class PersonService
    {
        private readonly IRepository _repository;

        public PersonService(IRepository repository)
        {
            _repository = repository;
        }

        public void DoSomething()
        {
            var person = _repository.GetBySpecification(
                new ByIdSpecification
                    {
                        Id = 1,
                        Persons = new List<Person>(new[]
                            {
                                new Person
                                    {
                                        Id = 2
                                    },
                                new Person {Id = 1}
                            })
                    });
        }

        public void DoSomethingElse()
        {
            var person = _repository.GetBySpecification(
                 new ByIdSpecification
                 {
                     Id = 1,
                     Persons = new List<Person>(new[]
                                            {
                                                new Person
                                                    {
                                                        Id = 2
                                                    },
                                                new Person {Id = 1}
                                            })
                 });
        }
    }
}