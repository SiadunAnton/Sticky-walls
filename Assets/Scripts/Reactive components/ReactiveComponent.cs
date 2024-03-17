using UnityEngine;

namespace Domain.Interactions.Triggered
{
    public abstract class ReactiveComponent : MonoBehaviour, IReactive
    {
        public virtual void OnEnter(GameObject anObject) { }

        public virtual void OnStay(GameObject anObject) { }

        public virtual void OnExit(GameObject anObject) { }
    }
}