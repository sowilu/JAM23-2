using System;
using System.Reflection;
using UnityEngine;

public class UnitySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    instance = obj.AddComponent<T>();
                    // call init function

                    if (Application.isEditor)
                    {
                        MethodInfo initMethod = typeof(T).GetMethod("Awake", BindingFlags.Instance | BindingFlags.NonPublic);
                        if (initMethod != null)
                        {
                            initMethod.Invoke(instance, null);
                        }
                    }
                }
            }
            

            return instance;
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }
}