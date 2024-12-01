using Entity.Stats;
using Signals;
using UnityEngine;
using Zenject;

namespace Entity
{
    public class Entity : MonoBehaviour
    {
        [Inject] protected SignalBus _signalBus;
        [Inject] protected DiContainer _diContainer;

        [SerializeField] protected Parameters _parameters;
        [SerializeField] protected HealthBehaviour _healthBehaviour;
        [SerializeField] protected bool _hasToReactOnGravity;

        public HealthBehaviour HealthBehaviour
        {
            get => _healthBehaviour;
            protected set { _healthBehaviour = value; }
        }

        public Parameters Parameters
        {
            get => _parameters;
            protected set { _parameters = value; }
        }

        protected virtual void Awake()
        {            
            _diContainer.Inject(_healthBehaviour);
            _healthBehaviour.Init();
            if (_hasToReactOnGravity)
                _signalBus.Subscribe<GravityModified>(OnGravitymodified);
        }

        protected virtual void OnGravitymodified(GravityModified modification)
        {
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, -modification.gravity.normalized) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1f);
        }
    }
}
