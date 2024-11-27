using RougeRPG.Service;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RougeRPG.Input
{
    public class InputService : IService
    {
        private InputActions _inputActions;

        public InputActions.PlayerActions Player => _inputActions.Player;
        
        public InputService()
        {
            _inputActions = new InputActions();
        }
        
        public override void OnUpdate()
        {
            
        }
    }
}
