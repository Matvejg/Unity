using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewService : MonoBehaviour, IViewService
{
    [SerializeField] ObjectView _player;
    [SerializeField] ObjectView _wall;

    ObjectView Create(GameObjectEnum type)
    {
        switch (type) {
            case GameObjectEnum.Wall:
                return Instantiate(_wall);
            case GameObjectEnum.Player:
                return Instantiate(_player);
            default:
                throw new NotImplementedException();
        }
    }

    public IView CreateView(int x, int y, GameObjectEnum type)
    {
        var obj = Create(type);
        obj.transform.SetParent(transform);
        obj.transform.localPosition = new Vector2(x, y);
        return obj.GetComponent<IView>();
    }
}
