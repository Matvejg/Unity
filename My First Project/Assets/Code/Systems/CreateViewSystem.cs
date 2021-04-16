using Leopotam.Ecs;

namespace Demo
{
    sealed class CreateViewSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = default;
        readonly IViewService _viewService = default;
        readonly EcsFilter<Position>.Exclude<View> _filter = default;

        void IEcsRunSystem.Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            foreach (var i in _filter)
            {
                ref var pos = ref _filter.Get1(i);
                var view = _viewService.CreateView(pos.Value.X, pos.Value.Y, pos.Value.Z);
                _filter.GetEntity(i).Get<View>().Value = view;
            }
        }
    }
}