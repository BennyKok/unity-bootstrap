using UnityEngine;
using UnityEngine.Events;

namespace BennyKok.Bootstrap
{
    public class OnStart : MonoBehaviour
    {
        public UnityEvent onStart;

        private void Start()
        {
            onStart.Invoke();
        }
    }
}