using System.Net.Mime;
using UnityEngine;

namespace BennyKok.Bootstrap
{
    public class TargetFPS : MonoBehaviour
    {
        public bool onlyOnMobile;
        public int targetFPS = 60;

        private void Awake()
        {
            if (!onlyOnMobile || (onlyOnMobile && Application.isMobilePlatform))
                Application.targetFrameRate = 60;
        }
    }
}