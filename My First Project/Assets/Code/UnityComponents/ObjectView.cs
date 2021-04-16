using System.Collections;
using UnityEngine;

namespace Demo
{
    public class ObjectView : MonoBehaviour, IView
    {
        public void UpdatePosition(int x, int y, int z)
        {
            transform.localPosition = new Vector3(x, y, z);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}