using Ecs;
using Leopotam.Ecs;

sealed class UpdatePlayerMoveTimerSystem : IEcsRunSystem
{
    readonly EcsFilter<Timer, Position, PlayerTag> _filter = default;

    void IEcsRunSystem.Run()
    {
        foreach (var i in _filter)
        {
            ref var t = ref _filter.Get1(i);
            t.Value -= UnityEngine.Time.deltaTime;
            if (t.Value <= 0)
            {
                _filter.GetEntity(i).Del<Timer>();
            }
        }
    }
}
