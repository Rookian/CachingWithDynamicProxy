using System;

namespace CachingWithDynamicProxy.DTOs
{
    [Serializable]
    public class Address
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
    }
}