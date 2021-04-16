using Leopotam.Ecs;
using UnityEngine;

namespace Demo
{
    [RequireComponent(typeof(ViewService))]
    [RequireComponent(typeof(InputService))]
    sealed class EcsStartup : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        void Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _systems
                // register your systems here, for example:
                .Add(new GameInitSystems())
                .Add(new InputSystem())
                .Add(new MoveObjectSystem())

                .Add(new CreateViewSystem())
                .Add(new MoveViewSystem())

                // register one-frame components (order is important), for example:
                .OneFrame<EcsInput>()
                .OneFrame<UpdatePositionFlag>()

                // inject service instances here (order doesn't important), for example:
                .Inject(GetComponent<IViewService>())
                .Inject(GetComponent<IInputService>())
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}