using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BennyKok.Bootstrap
{
    public class DestroyOnAwake : MonoBehaviour
    {
        private void Awake()
        {
            Destroy(gameObject);
        }
    }
}