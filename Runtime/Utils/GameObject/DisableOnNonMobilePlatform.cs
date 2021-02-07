using UnityEngine;

namespace BennyKok.Bootstrap
{
    public class DisableOnNonMobilePlatform : MonoBehaviour
    {
        public static bool IsMobilePlatform =>

#if UNITY_2021_1_OR_NEWER
            UnityEngine.Device.Application.isMobilePlatform;
#else
            Application.isMobilePlatform;
#endif

        private void Awake()
        {
            if (!IsMobilePlatform) gameObject.SetActive(false);
        }
    }
}