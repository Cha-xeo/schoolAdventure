using UnityEngine;
namespace SchoolAdventure.Games.Geographie.GeoGuesser
{

    public class ScreenShaker : MonoBehaviour
    {
        public float shakeDuration = 0.5f;
        public float shakeAmount = 0.1f;
        public float decreaseFactor = 1.0f;

        private Vector3 originalPosition;
        private float currentShakeDuration = 0f;

        private void Start()
        {
            originalPosition = transform.localPosition;
        }

        private void Update()
        {
            if (currentShakeDuration > 0)
            {
                Vector3 randomShake = Random.insideUnitSphere * shakeAmount;
                transform.localPosition = originalPosition + randomShake;

                currentShakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                currentShakeDuration = 0f;
                transform.localPosition = originalPosition;
            }
        }

        public void ShakeScreen()
        {
            currentShakeDuration = shakeDuration;
        }
    }
}
