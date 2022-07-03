using UnityEngine;

namespace Game.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = target.position;
        }
    }
}
