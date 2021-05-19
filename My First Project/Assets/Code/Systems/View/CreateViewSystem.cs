using Leopotam.Ecs;

namespace Demo
{
    sealed class CreateViewSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = default;
        readonly IViewService _viewService = default;
        readonly EcsFilter<Position, Color, ObjectType>.Exclude<View> _filter = default;

        void IEcsRunSystem.Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            foreach (var i in _filter)
            {
                ref var pos = ref _filter.Get1(i).Value;
                ref var color = ref _filter.Get2(i).Value;
                ref var type = ref _filter.Get3(i).Value;
                var view = _viewService.CreateView(pos.X, pos.Y, pos.Z, color, type);
                _filter.GetEntity(i).Get<View>().Value = view;
               
            } 
        }
    }
}