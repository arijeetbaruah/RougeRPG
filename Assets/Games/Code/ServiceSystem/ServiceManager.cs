using System;
using System.Collections.Generic;
using UnityEngine;

namespace RougeRPG.Service
{
    public class ServiceManager : MonoBehaviour
    {
        private static ServiceManager _instance;

        public static ServiceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "ServiceManager";
                    _instance = obj.AddComponent<ServiceManager>();
                }
                
                return _instance;
            }
        }
        
        public static bool HasInstance => _instance != null;
        
        private Dictionary<Type, IService> _services = new ();

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void OnDestroy()
        {
            _instance = null;
        }

        private void Update()
        {
            foreach (var service in _services.Values)
            {
                service.OnUpdate();
            }
        }
        
        public static void Add<T>(T service) where T : IService
        {
            Instance.AddService(service);
        }

        public void AddService<T>(T service) where T : IService
        {
            if (_services == null)
                _services = new Dictionary<Type, IService>();
            _services.Add(typeof(T), service);
        }

        public static T Get<T>() where T : IService
        {
            return Instance.GetService<T>();
        }

        public T GetService<T>() where T : IService
        {
            if (_services.TryGetValue(typeof(T), out IService service))
            {
                return (T)service;
            }

            return null;
        }

        public static void Remove<T>() where T : IService
        {
            Instance.RemoveService<T>();
        }

        public void RemoveService<T>() where T : IService
        {
            _services.Remove(typeof(T));
        }
    }
}
