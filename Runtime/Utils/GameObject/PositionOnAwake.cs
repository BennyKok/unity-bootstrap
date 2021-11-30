using System;
using UnityEngine;

namespace BennyKok.Bootstrap
{
    public class PositionOnAwake : MonoBehaviour
    {
        public bool setLocal = true;
        public Vector3 position = Vector3.zero;

        private void Awake()
        {
            if (setLocal)
                transform.localPosition = position;
            else
                transform.position = position;
        }
    }
}