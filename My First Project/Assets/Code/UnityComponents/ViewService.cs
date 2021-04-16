using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class ViewService : MonoBehaviour, IViewService
    {
        [SerializeField] ObjectView _gameObject;
        public IView CreateView(int x, int y, int z)
        {
            var obj = Instantiate(_gameObject);
            obj.transform.localPosition = new Vector3(x, y, z);
            return obj;
        }
    }
}
