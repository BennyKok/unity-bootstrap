using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BennyKok.Bootstrap
{
    public class DisableOnStart : MonoBehaviour
    {
        void Start()
        {
            gameObject.SetActive(false);
        }
    }
}