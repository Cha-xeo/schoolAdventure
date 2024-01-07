using SchoolAdventure.Audio;
using SchoolAdventure.Games.Lab.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SchoolAdventure.Games.Lab
{
    public class LabPickUp : MonoBehaviour
    {
        //public event Action<PickUp> onPickup;
        public AudioClip soundEffect;
        // public GameObject pickUpEffect;
        private void OnTriggerEnter2D(Collider2D other)
        {
            LabInventoryManager manager = other.GetComponent<LabInventoryManager>();
            if (manager)
            {
                bool pickedUp = manager.PickUpItem(gameObject);
                if (pickedUp)
                    RemoveItem();
            }
        }

        private void RemoveItem()
        {
            SoundManagerV2.Instance.PlaySound(soundEffect);
            //AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            // Instantiate(pickUpEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}