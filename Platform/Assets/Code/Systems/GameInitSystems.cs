using Ecs;
using Leopotam.Ecs;
using Leopotam.Ecs.Types;
using System;
using UnityEngine;

sealed class GameInitSystems : IEcsInitSystem
{
    // auto-injected fields.
    readonly EcsWorld _world = null;

    bool CreateObject(char type, out EcsEntity entity)
    {
        switch (type)
        {
            case 'o':
                {
                    entity = _world.NewEntity();
                    entity.Replace(new ObjectType
                    {
                        Value = GameObjectEnum.Wall
                    });
                    return true;
                }
            case 's':
                {
                    entity = _world.NewEntity();
                    entity.Get<PlayerTag>();
                    entity.Replace(new ObjectType
                    {
                        Value = GameObjectEnum.Player
                    });
                    return true;
                }
            default:
                {
                    entity = default;
                    return false;
                }
        }
    }

    public void Init()
    {
        var levelJson = Resources.Load<TextAsset>("Levels/Level01");
        var levelData = JsonUtility.FromJson<LevelModel>(levelJson.text);

        var levelEntity = _world.NewEntity();
        var level = new Level
        {
            size = new Int2(levelData.data.Length, levelData.data[0].Length)
        };
        level.data = new GameObjectEnum[level.size.Y * level.size.X];
        levelEntity.Replace(level);
        
        for (int y = 0; y < levelData.data.Length; y++)
        {
            var line = levelData.data[y];
            for (int x = 0; x < line.Length; x++)
            {
                if (CreateObject(line[x], out var e))
                {
                    e.Replace(new Position
                    {
                        Value = new Int2(x, level.size.Y - y - 1)
                    });
                }
            }
        }


    }
}