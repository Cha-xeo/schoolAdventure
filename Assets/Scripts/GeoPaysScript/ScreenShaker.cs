using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Geographie.GeoPays
{
    public class ScreenShaker : MonoBehaviour
    {
        public bool shaking = false;
        public float shakeDuration = 0.5f;
        public float shakeAmount = 0.1f;
        public float decreaseFactor = 1.0f;

        private Vector3 originalPosition;
        private float currentShakeDuration = 0f;

        private void Start()
        {

        }

        private void Update()
        {
            if (shaking)
            {
                if (currentShakeDuration > 0)
                {
                    Vector3 randomShake = Random.insideUnitSphere * shakeAmount;
                    transform.localPosition = originalPosition + randomShake;

                    currentShakeDuration -= Time.deltaTime * decreaseFactor;
                }
                else
                {
                    shaking = false;
                    currentShakeDuration = 0f;
                    transform.localPosition = originalPosition;
                }
            }
        }

        public void ShakeScreen()
        {
            shaking = true;
            originalPosition = transform.localPosition;
            currentShakeDuration = shakeDuration;
        }
    }
}