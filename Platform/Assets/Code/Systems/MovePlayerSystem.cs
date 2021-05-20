using Ecs;
using Leopotam.Ecs;
using Leopotam.Ecs.Types;
using System.Linq;
using UnityEngine;

sealed class MovePlayerSystem : IEcsRunSystem
{
    readonly EcsFilter<Ecs.Input> _input = default;
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
        if (!_player.IsEmpty())
        {
            ref var p = ref _player.Get1(0).Value;
            var newPos = new Int2(p.X + offset.X, p.Y + offset.Y);
            if (level.CanMove(newPos.X, p.Y))
            {
                SetPos(ref p, newPos.X, p.Y);
                return;
            }

            if (level.CanMove(p.X, newPos.Y))
            {
                SetPos(ref p, p.X, newPos.Y);
                return;
            }
        }
    }

    private void SetPos(ref Int2 p, int x, int y)
    {
        p.Set(x, y);
        ref var e = ref _player.GetEntity(0);
        e.Get<UpdatePositionFlag>();
        e.Replace(new Timer { Value = GameOptions.PlayerMoveSpeed });
    }
}