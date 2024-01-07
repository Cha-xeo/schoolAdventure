using UnityEngine;

namespace SchoolAdventure.Gameplay.UI
{
    public class UiHurt : MonoBehaviour
    {
        [SerializeField] Animation _hurtAnim;
        public static UiHurt Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public void PlayHurtAnim()
        {
            _hurtAnim.Play();
        }
    }
}