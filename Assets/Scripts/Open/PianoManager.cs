using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoManager : MonoBehaviour
{
    // Définir la couleur que vous souhaitez appliquer
    public Color nouvelleCouleur;
    public Color BaseCouleur;
    [SerializeField] AudioClip Note;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifier si le joueur a marché sur l'objet
        if (other.CompareTag("Player"))
        {
            SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(Note);
            // Changer la couleur de l'objet
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = nouvelleCouleur;
            }

            
            SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(6);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Vérifier si le joueur est sorti de l'objet
        if (other.CompareTag("Player"))
        {
            // Revenir à la couleur par défaut
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = BaseCouleur;
            }
        }
    }
}