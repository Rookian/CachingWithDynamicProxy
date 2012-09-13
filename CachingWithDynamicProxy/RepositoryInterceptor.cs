using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Castle.DynamicProxy;
using Newtonsoft.Json;
using ProtoBuf;

namespace CachingWithDynamicProxy
{
    public class RepositoryInterceptor : IInterceptor
    {
        private readonly MemoryCache _memoryCache;

        public RepositoryInterceptor()
        {
            _memoryCache = new MemoryCache("repositoryCache");
        }

        public void Intercept(IInvocation invocation)
        {
            var cacheKey = GenerateCacheKey(invocation.Method.Name, invocation.Arguments);
            if (_memoryCache.Get(cacheKey) != null)
            {
                invocation.ReturnValue = _memoryCache[cacheKey];
                return;
            }
            invocation.Proceed();

            _memoryCache[cacheKey] = invocation.ReturnValue;
        }

        private static string GenerateCacheKey(string methodName, IEnumerable<object> arguments)
        {
            if (arguments == null || !arguments.Any())
                return methodName;

            var stopwatch = new Stopwatch();

            using (var memoryStream = new MemoryStream())
            {

                stopwatch.Start();
                string argumentsKey = null;
                for (int i = 0; i < 1000; i++)
                {


                    //argumentsKey = JsonConvert.SerializeObject(arguments);
                    argumentsKey = SerializeObject(arguments);

                    //Serializer.Serialize(memoryStream, arguments);
                    //argumentsKey = Convert.ToBase64String(memoryStream.ToArray());
                }
                stopwatch.Stop();
                var elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;

                return methodName + "#" + argumentsKey;
            }
        }

        private static string SerializeObject(object source)
        {
            var binaryFormatter = new BinaryFormatter();

            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, source);
                return Convert.ToBase64String(memoryStream.GetBuffer());
            }
        }
    }
}