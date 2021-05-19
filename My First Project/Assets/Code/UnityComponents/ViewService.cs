using Leopotam.Ecs.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class ViewService : MonoBehaviour, IViewService
    {
        [SerializeField] ObjectView _cube;
        [SerializeField] ObjectView _sphere;
        [SerializeField] ObjectView _capsule;

        ObjectView CreateObject(ObjectTypeEnum type)
        {
            switch (type)
            {
                case ObjectTypeEnum.Capsule:
                    return Instantiate(_capsule);
                case ObjectTypeEnum.Sphere:
                    return Instantiate(_sphere);
                case ObjectTypeEnum.Cube:
                    return Instantiate(_cube);
                default:
                    throw new System.NotImplementedException();
            }
        }

        public IView CreateView(int x, int y, int z, Float3 color, ObjectTypeEnum type)
        {
            var obj = CreateObject(type);
            obj.transform.localPosition = new Vector3(x, y, z);

            var mr = obj.GetComponent<MeshRenderer>();
            var mat = Instantiate(mr.material);
            mat.color = new UnityEngine.Color(color.X, color.Y, color.Z);
            mr.material = mat;

            return obj;
        }
    }
}
