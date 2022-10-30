using UnityEngine;
using VContainer;

namespace Castle.DynamicProxy.DurationInterceptorSample {
    public class GreetBehaviour : MonoBehaviour {
        [SerializeField] string _name;

        [Inject] IGreetService _greetService;

        bool _greeting;

        void Update() {
            if (!_greeting) {
                _greeting = true;
                _greetService.Greet(_name);
                _greeting = false;
            }
        }
    }
}
