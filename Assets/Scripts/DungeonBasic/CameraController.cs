using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Dungeon.Generation
{
    public class CameraController : MonoBehaviour
    {

        public static CameraController instance { get; private set; }
        public Room currRoom;
        public float moveSpeedWhenRoomChange;
        bool _activated = false;

        void Awake()
        {
            if (instance)
            {
                Destroy(instance);
            }
            else
            {
                instance = this;
            }
        }

        // Update is called once per frame
        void Update()
        {
            UpdatePosition();
        }

        void UpdatePosition()
        {
            if (currRoom == null)
            {
                return;
            }

            Vector3 targetPos = GetCameraTargetPosition();

            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeedWhenRoomChange);
        }

        Vector3 GetCameraTargetPosition()
        {
            if (currRoom == null)
            {
                return Vector3.zero;
            }

            Vector3 targetPos = currRoom.GetRoomCentre();
            targetPos.z = transform.position.z;

            return targetPos;
        }

        public bool IsSwitchingScene()
        {
            return transform.position.Equals(GetCameraTargetPosition()) == false;
        }
    }
}
