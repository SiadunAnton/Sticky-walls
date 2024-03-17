using UnityEngine;

namespace Domain.Movement.Input
{
    public class MobileInputSignature : IConcreteInputSignature
    {
        public bool IsPressed()
        {
            return UnityEngine.Input.touchCount == 0;
        }

        public bool IsPressEnded()
        {
            return UnityEngine.Input.GetTouch(0).phase == TouchPhase.Ended;
        }

        public bool IsPressStarted()
        {
            return UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began;
        }
    }
}