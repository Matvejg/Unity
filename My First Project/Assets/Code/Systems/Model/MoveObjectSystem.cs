using Leopotam.Ecs;

namespace Demo
{
    sealed class MoveObjectSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly EcsFilter<EcsInput> _input = default;
        readonly EcsFilter<Position, View> _objects = default;
        readonly Rnd _rnd = default;
        void IEcsRunSystem.Run()
        {
            if (_input.IsEmpty())
            {
                return;
            }

            foreach (var i in _input)
            {
                ref var offset = ref _input.Get1(i).Value;
                foreach (var o in _objects)
                {
                    ref var pos = ref _objects.Get1(o).Value;
                    var x = _rnd.Next(-10, 10);
                    var y = _rnd.Next(-10, 10);
                    var z = _rnd.Next(-10, 10);
                    pos.Set(x, y, z);
                   
                    _objects.GetEntity(o).Get<UpdatePositionFlag>();
                }
            }
        }
    }
}