using CachingWithDynamicProxy.DTOs;
using Castle.DynamicProxy;
using ProtoBuf.Meta;
using StructureMap;

namespace CachingWithDynamicProxy
{
    class Program
    {
        static void Main()
        {
            var container = new Container();
            Booting(container);
            var configuration = new Configuration();

            RuntimeTypeModel.Default.Add(typeof(ByIdSpecification), false).Add("Id", "Name", "Persons");
            RuntimeTypeModel.Default.Add(typeof(Person), false).Add("Id", "Name", "Address");
            RuntimeTypeModel.Default.Add(typeof(Address), false).Add("Street", "Number", "City");

            //configuration.AddType<ByIdSpecification>();
            //configuration.AddType<Person>();
            //configuration.AddType<Address>();
            
            //configuration.AddTypes(x =>
            //{
            //    x.WithOptionsFromAssemblyContainingType<Address>().WithNamespace("DTOS");
            //});

            var personService = container.GetInstance<PersonService>();

            personService.DoSomething();
            personService.DoSomethingElse();
        }

        private static void Booting(Container container)
        {
            container.Configure(config =>
            {
                var proxyGenerator = new ProxyGenerator();

                config.For<IRepository>().EnrichAllWith(
                    repository => proxyGenerator.CreateInterfaceProxyWithTarget(repository, new RepositoryInterceptor())).
                    Use<Repository>();
            });
        }
    }
}
