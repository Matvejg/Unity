using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewService : MonoBehaviour, IViewService
{
    [SerializeField] ObjectView _player;

    public IView CreateView(int x, int y)
    {
        var obj = Instantiate(_player);
        return obj.GetComponent<IView>();
    }
}
