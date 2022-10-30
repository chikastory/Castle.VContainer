using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Castle.DynamicProxy.DurationInterceptorSample {
    public class DurationInterceptor : IInterceptor {
        public void Intercept(IInvocation invocation) {
            var sw = Stopwatch.StartNew();
            try {
                invocation.Proceed();
            } finally {
                sw.Stop();
                Debug.LogFormat("{0} took {1}ms", invocation.Method.Name, sw.ElapsedMilliseconds);
            }
        }
    }
}
