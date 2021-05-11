using UnityEngine;
using UnityEngine.Events;

namespace BennyKok.Bootstrap
{
    public class OnTriggerEvent : MonoBehaviour
    {
        public string checkTag;

        public UnityEvent onEnter;

        public UnityEvent onExit;

        private void OnTriggerEnter(Collider other)
        {
            if (Compare(other))
                InvokeOnEnter();
        }

        private void OnTriggerExit(Collider other)
        {
            if (Compare(other))
                InvokeOnExit();
        }

        public bool Compare(Collider col)
        {
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