using UnityEngine;

namespace Aytona.Effects
{
    public class ConstRotObj : MonoBehaviour
    {
        public Vector3 rotation;
        void Update()
        {
            gameObject.transform.Rotate(rotation * Time.deltaTime);
        }
    }

}