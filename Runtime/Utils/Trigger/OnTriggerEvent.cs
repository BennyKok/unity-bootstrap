using UnityEngine;
using UnityEngine.Events;

namespace BennyKok.Bootstrap
{
    public class OnTriggerEvent : MonoBehaviour
    {
        public string checkTag;
        public bool triggerOnce;

        private bool triggered;

        public UnityEvent onEnter;

        public UnityEvent onExit;

        private void Start()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (!enabled) return;
            if (Compare(other))
                InvokeOnEnter();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!enabled) return;
            if (Compare(other))
                InvokeOnExit();
        }

        public bool Compare(Collider col)
        {
            if (triggerOnce && triggered) return false;
            triggered = true;
            if (string.IsNullOrEmpty(checkTag)) return true;
            if (col.CompareTag(checkTag)) return true;

            return false;
        }

        public void InvokeOnEnter()
        {
            onEnter.Invoke();
        }

        public void InvokeOnExit()
        {
            onExit.Invoke();
        }
    }
}