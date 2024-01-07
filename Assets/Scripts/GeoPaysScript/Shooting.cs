using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Geographie.GeoPays
{
    public class Shooting : MonoBehaviour
    {
        //private Camera mainCam;
        private Vector3 mousePos;
        public GameObject bullet;
        public Transform bulletTransform;
        public bool canFire;
        private float timer;
        public float timeBetweenFiring;
        private PlayerMovment playerMovement;

        // Start is called before the first frame update
        void Start()
        {
          //  mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            playerMovement = GameObject.FindObjectOfType<PlayerMovment>();
        }

        // Update is called once per frame
        void Update()
        {
            //mousePos = mainCam.ScreenToWorldPoint(InputManager.GetInstance().GetMousePosition() Input.mousePosition);
            mousePos = InputManager.GetInstance().GetMousePosition();

            Vector3 rotation = mousePos - transform.position;

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            if (playerMovement.isFacingRight)
            {
                transform.rotation = Quaternion.Euler(0, 0, rotZ);
            }
            else
            {
                rotZ = Mathf.Atan2(rotation.y, -rotation.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, -rotZ);
            }

            // Left Click Shoot
            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenFiring)
                {
                    canFire = true;
                    timer = 0;
                }
            }

            if (InputManager.GetInstance().GetFirePressed() && canFire)
            {
                canFire = false;
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            }
        }
    }
}