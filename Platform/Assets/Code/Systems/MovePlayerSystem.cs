using Ecs;
using Leopotam.Ecs;
using System.Linq;

sealed class MovePlayerSystem : IEcsRunSystem
{
    readonly EcsFilter<Input> _input = default;
    readonly EcsFilter<Position, PlayerTag>.Exclude<Timer> _player = default;

    void IEcsRunSystem.Run()
    {
        if (_input.IsEmpty())
        {
            return;
        }
        ref var offset = ref _input.Get1(0).Offset;
        
        foreach (var i in _player)
        {
            ref var p = ref _player.Get1(i).Value;
            p.Set(p.X + offset.X, p.Y + offset.Y);
            var e = _player.GetEntity(i);
            e.Get<UpdatePositionFlag>();
            e.Replace(new Timer { Value = GameOptions.PlayerMoveSpeed });
        }
    }
}