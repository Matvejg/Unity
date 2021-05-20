using Ecs;
using Leopotam.Ecs;


sealed class MoveViewSystem : IEcsRunSystem
{
    // auto-injected fields.
    readonly EcsWorld _world = null;
    readonly EcsFilter<Position, View, PlayerTag, UpdatePositionFlag> _player = default;

    void IEcsRunSystem.Run()
    {
        foreach (var i in _player)
        {
            ref var p = ref _player.Get1(i).Value;
            ref var v = ref _player.Get2(i).Value;
            v.UpdatePosition(p.X, p.Y);
        }
    }
}
