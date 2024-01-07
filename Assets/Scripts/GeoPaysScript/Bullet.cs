using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Geographie.GeoPays
{
    public class Bullet : MonoBehaviour
    {
        private Vector3 mousePos;
        //private Camera mainCam;
        private Rigidbody2D rb;
        public float force;

        public StageGenerator stageGenerator;

        // Start is called before the first frame update
        void Start()
        {
            //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            rb = GetComponent<Rigidbody2D>();
            //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            mousePos = mousePos = InputManager.GetInstance().GetMousePosition();
            Vector3 direction = mousePos - transform.position;
            Vector3 rotation = transform.position - mousePos;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);
            Destroy(gameObject, 3);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("WallReset") || other.gameObject.CompareTag("Glue") ||
            other.gameObject.CompareTag("Death") || other.gameObject.CompareTag("Target"))
            {
                DestroyProjectile();
            }
            if (other.gameObject.CompareTag("Target"))
            {
                Target targetScript = other.gameObject.GetComponent<Target>();
                targetScript.TargetHit();
            }
        }

        void DestroyProjectile()
        {
            Destroy(gameObject);
        }
    }
}