using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BK.Bootstrap
{
    public class DestroyOnAwake : MonoBehaviour
    {
        private void Awake()
        {
            Destroy(gameObject);
        }
    }
}