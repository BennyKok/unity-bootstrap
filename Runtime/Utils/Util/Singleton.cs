using UnityEngine;

namespace BennyKok.Bootstrap
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T m_Instance;

        public static T Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public abstract void OnAwake();

        protected virtual void Awake()
        {
            if (m_Instance)
                Destroy(m_Instance.gameObject);

            m_Instance = GetComponent<T>();

            OnAwake();
        }
    }
}