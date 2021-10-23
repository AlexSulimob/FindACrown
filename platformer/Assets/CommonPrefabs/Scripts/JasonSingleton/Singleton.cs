using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JasonWeimannSingleton
{
    public class Singleton<T> : MonoBehaviour
        where T: MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        Debug.LogError("Error Singleton instance not found  " + typeof(T));
                        var go = new GameObject("Instance of" + typeof(T));
                        _instance = go.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
