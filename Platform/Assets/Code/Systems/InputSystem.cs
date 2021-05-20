using Ecs;
using Leopotam.Ecs;
using System.Linq;

sealed class InputSystem : IEcsRunSystem
{
    // auto-injected fields.
    readonly EcsWorld _world = null;
    readonly IInputService _input = default;
    readonly EcsFilter<Position, PlayerTag> _player = default;

    void IEcsRunSystem.Run()
    {
        if (_input.GetOffset(out var offset))
        {
            foreach (var i in _player)
            {
                var e = _player.GetEntity(i);
                if (!e.Has<Timer>())
                {
                    ref var p = ref _player.Get1(i).Value;
                    p.Set(p.X + offset.X, p.Y + offset.Y);
                    e.Get<UpdatePositionFlag>();
                    e.Replace(new Timer { Value = GameOptions.PlayerMoveSpeed });
                }
            }
        }
    }
}