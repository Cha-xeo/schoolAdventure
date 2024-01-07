using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Langues.GenderDetective
{
    public class FindGameHealth : MonoBehaviour
    {
        [SerializeField] Image m_Image;
        private void Start()
        {
            GameManager.HealthCHanged += SetHealth;
        }
        public void SetHealth(int amount)
        {
            float tmp = (float)amount;
            m_Image.fillAmount = tmp/GameManager.Instance.maxHealth;
        }

        private void OnDestroy()
        {
            GameManager.HealthCHanged -= SetHealth;
        }
    }
}