using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Geographie.GeoPays
{
    public class CameraScroll : MonoBehaviour
    {
        private Vector3 offset = new Vector3(0f, 0f, -10f);
        private float smoothTime = 0.25f;
        private Vector3 velocity = Vector3.zero;

        [SerializeField] private Transform target;

        private void Update()
        {
            float tmp = target.position.x;
            if (tmp < 16.006f)
                tmp = 16.006f;
            if (tmp > 29.14f)
                tmp = 29.14f;
            Vector3 targetPosition = new Vector3(tmp, transform.position.y, target.position.z) + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}