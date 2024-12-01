using Entity.Stats;
using UnityEngine;
using Zenject;

namespace Entity 
{
    [RequireComponent(typeof(Entity))]
    public class EntityInstaller : MonoInstaller
    {
        [SerializeField] private Entity _entity;

        public override void InstallBindings()
        {
            Container.Bind<Entity>().FromInstance(_entity).AsSingle();
            Container.Bind<Parameters>().FromInstance(_entity.Parameters).AsSingle();
            Container.Bind<HealthBehaviour>().FromInstance(_entity.HealthBehaviour).AsSingle();
        }
    }
}
