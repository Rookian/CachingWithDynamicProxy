using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ProtoBuf.Meta;

namespace CachingWithDynamicProxy
{
    public class Configuration
    {
        private readonly ICollection<Type> _types;

        public Configuration()
        {
            _types = new Collection<Type>();
        }

        public ICollection<Type> RegisteredTypes
        {
            get { return _types; }
        }

        public Configuration AddType<T>()
        {
            var type = typeof(T);
            AddType(type);
            return this;
        }

        public TypeConfigurationExpression AddTypes()
        {
            var typeConfigurationExpression = new TypeConfigurationExpression(x => AddType(x));
            return typeConfigurationExpression;
        }


        public void AddTypes(Action<TypeConfigurationExpression> typeConfiguration)
        {
            typeConfiguration.Invoke(new TypeConfigurationExpression(x => AddType(x)));
        }

        public Configuration AddType(Type type)
        {
            RuntimeTypeModel.Default.Add(type, false).Add(type.GetProperties().Select(x => x.Name).ToArray());
            _types.Add(type);
            return this;
        }
    }

    public class TypeConfigurationExpression
    {
        private readonly Action<Type> _action;

        public TypeConfigurationExpression(Action<Type> action)
        {
            _action = action;
        }

        public TypeOptionExpression WithOptionsFromAssemblyContainingType<T>()
        {
            return new TypeOptionExpression(typeof(T).Assembly.GetTypes(), Execute);
        }

        public void FromAssemblyContainingType<T>()
        {
            Execute(typeof(T).Assembly.GetTypes());
        }

        private void Execute(IEnumerable<Type> types)
        {
            types.ToList().ForEach(_action);
        }
    }

    public class TypeOptionExpression
    {
        private readonly IEnumerable<Type> _types;
        private readonly Action<IEnumerable<Type>> _execute;

        public TypeOptionExpression(IEnumerable<Type> types, Action<IEnumerable<Type>> execute)
        {
            _types = types;
            _execute = execute;
        }

        public void WithNamespace(string @namespace)
        {
            var types = _types.Where(x => x.Namespace != null && x.Namespace.EndsWith(@namespace, StringComparison.InvariantCultureIgnoreCase));
            _execute(types);
        }
    }
}