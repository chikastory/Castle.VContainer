using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Castle.DynamicProxy.DurationInterceptorSample {
    public sealed class GreetService : IGreetService {
        public void Greet(string name) {
            var end = DateTime.Now + TimeSpan.FromMilliseconds(100 * Random.value);
            while (DateTime.Now < end) { }

            Debug.LogFormat("hello, {0}", name);
        }
    }
}
