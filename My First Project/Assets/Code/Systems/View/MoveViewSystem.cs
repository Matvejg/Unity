using Leopotam.Ecs;

namespace Demo
{
    sealed class MoveViewSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<Position, View, UpdatePositionFlag> _filter = default;

        void IEcsRunSystem.Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            foreach (var i in _filter)
            {
                ref var pos = ref _filter.Get1(i);
                ref var view = ref _filter.Get2(i);
                view.Value.UpdatePosition(pos.Value.X, pos.Value.Y, pos.Value.Z);
            }
        }
    }
}