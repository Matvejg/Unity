using Leopotam.Ecs.Types;

namespace Ecs
{
    static class LevelExtension
    {
        public static int GetIndex(this ref Level level, int x, int y)
        {
            if (x < 0)
            {
                return -1;
            }
            if (y < 0)
            {
                return -1;
            }
            if (x >= level.size.X)
            {
                return -1;
            }
            if (y >= level.size.Y)
            {
                return -1;
            }

            var index = y * level.size.X + x;
            return index;
        }

        public static bool CanMove(this ref Level level, int x, int y)
        {
            var index = level.GetIndex(x, y);
            if (index == -1)
            {
                return false;
            }

            return level.data[index] == GameObjectEnum.None;
        }
    }
}