using UnityEngine;

namespace SchoolAdventure.DungeonPuzzle.Player.Elements
{
    public class PlayerElementHolder : MonoBehaviour
    {
        [SerializeField] Transform _playerTransform;
        [SerializeField] Transform _holderTransform;
        [SerializeField] float _revSpeed;
        [SerializeField] float _rotDir;
        [SerializeField] float _rotationModifier;
        Vector3 rotate;
        private Vector3 _vectorToTarget;
        private float _angle;
        private void Start()
        {
            rotate = new Vector3(0, 0, _rotDir);
        }
        private void FixedUpdate()
        {
            _FaceTarget();
            _holderTransform.RotateAround(_playerTransform.position, rotate, Time.fixedDeltaTime * _revSpeed);
        }

        private void _FaceTarget()
        {
            _vectorToTarget = _playerTransform.position - _holderTransform.position;
            _angle = Mathf.Atan2(_vectorToTarget.y, _vectorToTarget.x) * Mathf.Rad2Deg - _rotationModifier;
            _holderTransform.rotation = Quaternion.Slerp(_holderTransform.rotation, Quaternion.AngleAxis(_angle, Vector3.forward), Time.fixedDeltaTime * _revSpeed);

        }
    }
}
