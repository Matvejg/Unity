using Ecs;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcsStartup : MonoBehaviour
{
    EcsWorld _world;
    EcsSystems _systems;

    void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
        _systems
            .Add(new GameInitSystems() )

            .Add(new InputSystem())
            .Add(new UpdatePlayerMoveTimerSystem())
            .Add(new MovePlayerSystem())

            .Add(new CreateViewSystem() )
            .Add(new MoveViewSystem() )

            .OneFrame<Ecs.Input>()
            .OneFrame<UpdatePositionFlag>()

            .Inject(GetComponent<IViewService>())
            .Inject(GetComponent<IInputService>())
            .Init();

    }

    // Update is called once per frame
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
