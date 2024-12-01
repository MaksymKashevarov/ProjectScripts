using UnityEngine;
using Entity.Stats;
using Zenject;
using Entity.Iteractable;

namespace Entity.Player.IteractModes
{
    [System.Serializable]
    public class RaycastIteractMode : IIteractable
    {
        [SerializeField] private float _distance = 2f;
        //private float _radius = 0.5f;
        private MonoIteractable _currentInteractable;
        [Inject] private Parameters _parameters;

        public bool IsPossibleToIteract()
        {
            _currentInteractable = null;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (!Physics.Raycast(ray, out var hitInfo, _distance))
                return false;

            if (!hitInfo.transform.TryGetComponent(out _currentInteractable))
                return false;

            /*Collider[] colliders = Physics.OverlapSphere(Camera.main.transform.position, _radius);
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out _currentInteractable))
                    return true;
            }*/

            return true;
        }

        public void Iteract()
        {
            _currentInteractable.Iteract();
            _currentInteractable = null;
        }
    }
}
