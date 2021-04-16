using Leopotam.Ecs;

namespace Demo
{
    sealed class MoveObjectSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<EcsInput> _input = default;
        readonly EcsFilter<Position, View> _objects = default;

        void IEcsRunSystem.Run()
        {
            if (_input.IsEmpty())
            {
                return;
            }

            foreach (var i in _input)
            {
                ref var offset = ref _input.Get1(i);
                foreach (var o in _objects)
                {
                    ref var pos = ref _objects.Get1(o);
                    pos.Value.Set(pos.Value.X + offset.Value.X, pos.Value.Y + offset.Value.Y, pos.Value.Z + offset.Value.Z);
                    _objects.GetEntity(o).Get<UpdatePositionFlag>();
                }
            }
        }
    }
}