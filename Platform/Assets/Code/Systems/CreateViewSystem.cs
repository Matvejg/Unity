using Ecs;
using Leopotam.Ecs;

sealed class CreateViewSystem : IEcsRunSystem
{
    readonly EcsWorld _world = default;
    readonly EcsFilter<Position>.Exclude<View> _filter = default;
    readonly IViewService _viewService = default;
    void IEcsRunSystem.Run()
    {
        if (_filter.IsEmpty())
        {
            return;
        }

        foreach (var i in _filter)
        {
            ref var pos = ref _filter.Get1(i).Value;
             var view = _viewService.CreateView(pos.X, pos.Y);
            _filter.GetEntity(i).Get<View>().Value = view;

        }
    }

}
