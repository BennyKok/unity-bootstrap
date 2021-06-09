using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;

namespace BennyKok.Bootstrap
{
    public class DelayedUnityEvent : MonoBehaviour
    {
        public float delay;
        public UnityEvent targetEvent;

        public void Invoke()
        {
            StartCoroutine(DelayEvent());
        }

        public IEnumerator DelayEvent()
        {
            yield return new WaitForSeconds(delay);
            targetEvent.Invoke();
        }
    }
}