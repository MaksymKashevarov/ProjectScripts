using Entity.Stats;
using Zenject;

namespace Entity {
    [System.Serializable]
    public class HealthBehaviour
    {
        private Parameter<bool> _isInvincible;
        [Inject] private Parameters _parameters;

        public void Init()
        {
            _isInvincible = _parameters.GetAs<Parameter<bool>>("isInvincible");
        }
    }
}
