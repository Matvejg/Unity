using Ecs;
using Leopotam.Ecs;
using Leopotam.Ecs.Types;

sealed class GameInitSystems : IEcsInitSystem
{
    // auto-injected fields.
    readonly EcsWorld _world = null;

    public void Init()
    {
        var e = _world.NewEntity();
        e.Get<PlayerTag>();
        e.Replace(new Position { 
            Value = new Int2(0,0)
        });

    }
}