using System;
using System.Collections.Generic;

namespace CachingWithDynamicProxy.DTOs
{
    [Serializable]
    public class ByIdSpecification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> Persons { get; set; }
    }
}