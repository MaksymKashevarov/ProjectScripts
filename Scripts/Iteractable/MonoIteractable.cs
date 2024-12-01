using UnityEngine;
using UnityEngine.Events;

namespace Entity.Iteractable
{
    public class MonoIteractable : MonoBehaviour, IIteractable
    {
        public UnityEvent onIteract;
        [SerializeField] private bool _toDebug;
        [SerializeField] private bool _isPossibleToIteract;
        public virtual void Iteract()
        {
            if (_toDebug)
                Debug.Log("Interacted with " + gameObject.name);

            onIteract.Invoke();
        }

        public virtual bool IsPossibleToIteract()
            => _isPossibleToIteract;
    }
}
