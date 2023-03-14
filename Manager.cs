using UnityEngine;

namespace TechBear.Manager
{
    public abstract class Manager<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Private Variables

        private static T _instance;

        #endregion

        #region Properties

        public static T Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();
                    DontDestroyOnLoad(singletonObject);
                }

                return _instance;
            }
        }

        #endregion

        #region MonoBehavior Methods

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}