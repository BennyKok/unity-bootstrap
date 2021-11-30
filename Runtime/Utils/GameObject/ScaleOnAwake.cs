using System;
using UnityEngine;

namespace BennyKok.Bootstrap
{
    public class ScaleOnAwake : MonoBehaviour
    {
        public Vector3 scale = Vector3.one;

        private void Awake()
        {
            transform.localScale = scale;
        }
    }
}