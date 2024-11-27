using System;
using RougeRPG.Input;
using RougeRPG.Service;
using UnityEngine;

namespace RougeRPG
{
    public class ServiceBinder : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        
        private void Start()
        {
            ServiceManager.Add(new InputService());
            
            Instantiate(_playerPrefab);
            Debug.Log("Game Started");
        }
    }
}
