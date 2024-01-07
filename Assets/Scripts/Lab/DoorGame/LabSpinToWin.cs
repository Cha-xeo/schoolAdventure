using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Lab.Door
{
    public class LabSpinToWin : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _thisTransform;
        [SerializeField] private float _rotationModifier;
        private Vector3 _vectorToTarget;
        private float _angle;
        public float revSpeed;
        public float rotDir;
        public float _revSpeed;
        public float _rotDir;

        void FixedUpdate()
        {
            _FaceTarget();
            _thisTransform.RotateAround(_target.position, new Vector3(0f, 0f, _rotDir), Time.fixedDeltaTime * _revSpeed);
        }

        private void _FaceTarget()
        {
            _vectorToTarget = _target.position - _thisTransform.position;
            _angle = Mathf.Atan2(_vectorToTarget.y, _vectorToTarget.x) * Mathf.Rad2Deg - _rotationModifier;
            _thisTransform.rotation = Quaternion.Slerp(_thisTransform.rotation, Quaternion.AngleAxis(_angle, Vector3.forward), Time.deltaTime * _revSpeed);

        }
        private void OnEnable()
        {
            _revSpeed = revSpeed;
            _rotDir = rotDir;
        }
    }
}