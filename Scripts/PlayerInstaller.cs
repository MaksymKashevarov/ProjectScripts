using UnityEngine;
using Entity.Player.Movement;
using UnityEngine.InputSystem;
using Cinemachine;
using Entity.Player.IteractModes;
using Entity.Iteractable;

namespace Entity.Player
{
    public class PlayerInstaller : EntityInstaller
    {
        [SerializeField] private PlayerInput _input;
        [SerializeField] private Inventory _inventory;
        [SerializeField, SerializeReference] private IIteractable _iteractable;

        [Header("Player Movement")]
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private CapsuleCollider _collider;
        [SerializeField] private MovementStateMachine _movementStateMachine;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        private GroundedCheck _groundedCheck;

        public override void InstallBindings()
        {
            base.InstallBindings();
            Inventory.currentInstance = _inventory;
            _iteractable = new RaycastIteractMode();
            _groundedCheck = new GroundedCheck(transform);
            ApplyBindings();
            Container.Inject(_iteractable);
        }

        private void ApplyBindings()
        {
            BindInstances();
        }

        private void BindInstances()
        {
            Container.Bind<PlayerInput>().FromInstance(_input).AsSingle();
            Container.Bind<Inventory>().FromInstance(_inventory).AsSingle();
            Container.Bind<IIteractable>().FromInstance(_iteractable).AsSingle();
            Container.Bind<CapsuleCollider>().FromInstance(_collider).AsSingle();
            Container.Bind<Rigidbody>().FromInstance(_rigidbody).AsSingle();
            Container.Bind<MovementStateMachine>().FromInstance(_movementStateMachine).AsSingle();
            Container.Bind<CinemachineVirtualCamera>().FromInstance(_virtualCamera).AsSingle();
            Container.Bind<MovementStateMachine.DefinedStates>().FromInstance(_movementStateMachine.States).AsSingle();
            Container.Bind<GroundedCheck>().FromInstance(_groundedCheck).AsSingle();
        }
    }
}
