using UnityEngine;

namespace Domain.Movement.Input
{
    public class PCInputSignature : IConcreteInputSignature
    {
        public bool IsPressed()
        {
            return UnityEngine.Input.GetKey(KeyCode.Space);
        }

        public bool IsPressEnded()
        {
            return UnityEngine.Input.GetKeyUp(KeyCode.Space);
        }

        public bool IsPressStarted()
        {
            return UnityEngine.Input.GetKeyDown(KeyCode.Space);
        }
    }
}