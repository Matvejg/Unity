using Ecs;
using Leopotam.Ecs;
using Leopotam.Ecs.Types;
using System.Linq;

sealed class MovePlayerSystem : IEcsRunSystem
{
    readonly EcsFilter<Input> _input = default;
    readonly EcsFilter<Level> _level = default;
    readonly EcsFilter<Position, ObjectType> _objects = default;
    readonly EcsFilter<Position, PlayerTag>.Exclude<Timer> _player = default;

    void IEcsRunSystem.Run()
    {
        if (_input.IsEmpty())
        {
            return;
        }
        ref var offset = ref _input.Get1(0).Offset;

        // обновляем уровень
        ref var level = ref _level.Get1(0);
        for (int i = 0; i < level.data.Length; i++)
        {
            level.data[i] = GameObjectEnum.None;
        }

        foreach (var i in _objects)
        {
            ref var p = ref _objects.Get1(i).Value;
            ref var t = ref _objects.Get2(i).Value;
            var index = level.GetIndex(p.X, p.Y);
            if (index > -1)
            {
                level.data[index] = t;
            }
        }

        foreach (var i in _player)
        {
            ref var p = ref _player.Get1(i).Value;
            var newPos = new Int2(p.X + offset.X, p.Y + offset.Y);
            if (level.CanMove(newPos.X, p.Y))
            {
                p.Set(newPos.X, p.Y);
                var e = _player.GetEntity(i);
                e.Get<UpdatePositionFlag>();
                e.Replace(new Timer { Value = GameOptions.PlayerMoveSpeed });
                return;
            }

            if (level.CanMove(p.X, newPos.Y))
            {
                p.Set(p.X, newPos.Y);
                var e = _player.GetEntity(i);
                e.Get<UpdatePositionFlag>();
                e.Replace(new Timer { Value = GameOptions.PlayerMoveSpeed });
                return;
            }
        }
    }
}