using UnityEngine;

namespace SchoolAdventure.Dungeon.Player.Gameplay
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] float attackSpeed;
        [SerializeField] GameObject bulletPrefab;
        Transform _waitingPos;
        GameObject[] _bulletsPollArray = new GameObject[20];
        float _nextShot = 0f;
        public float bulletSpeed;
        Vector2 _moveInput;
        int max;
        public int _currentShot { get; private set; }

        private void Start()
        {
            _waitingPos = GameObject.FindGameObjectWithTag(Constants.TAG_MATCHINGZONEFADDED).transform;
            _currentShot = 0;
            max = _bulletsPollArray.Length;
            for (int i = 0; i < max; i++)
            {
                _bulletsPollArray[i] = Instantiate(bulletPrefab, _waitingPos.position, Quaternion.identity, _waitingPos);
                _bulletsPollArray[i].AddComponent<Rigidbody2D>().gravityScale = 0;
                _bulletsPollArray[i].SetActive(false);
            }
        }
        /*private void Update()
        {
            if (InputManager.GetInstance().GetFirePressed())
            {
                _moveInput = InputManager.GetInstance().GetMoveDirection();
                ShootBullet(_moveInput.x, _moveInput.y);
            }
        }*/

        void ShootBullet(float x, float y)
        {
            if (_nextShot + attackSpeed < Time.time)
            {
                _bulletsPollArray[_currentShot].SetActive(true);
                _bulletsPollArray[_currentShot].transform.position = transform.position;
                _bulletsPollArray[_currentShot].GetComponent<Rigidbody2D>().velocity = new Vector3(
                    (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
                    (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
                    0
                );
                _currentShot++;
                _nextShot = Time.time;
                if (_currentShot >= max) _currentShot = 0;
            }
        }
    }
}
