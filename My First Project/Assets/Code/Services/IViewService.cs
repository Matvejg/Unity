using Leopotam.Ecs;

namespace Demo
{
    public interface IViewService
    {
        IView CreateView(int x, int y, int z);
    }
}