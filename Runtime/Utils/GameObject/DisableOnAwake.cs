using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BK.Bootstrap
{
    public class DisableOnAwake : MonoBehaviour
    {
        private void Awake()
        {
            gameObject.SetActive(false);
        }
    }
}