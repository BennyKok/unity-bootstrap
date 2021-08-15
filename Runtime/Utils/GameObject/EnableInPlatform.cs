using System.Collections.Generic;
using UnityEngine;

namespace BennyKok.Bootstrap
{
    public class EnableInPlatform : MonoBehaviour
    {
        public List<RuntimePlatform> targetPlatforms;

        private void Start()
        {
            if (targetPlatforms.Contains(Application.platform))
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}