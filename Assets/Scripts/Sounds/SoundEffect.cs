using SchoolAdventure.Audio;
using UnityEngine;

namespace SchoolAdventure.Games.Lab.Audio
{
    public class SoundEffect : MonoBehaviour
    {
        public AudioClip[] walkingSound;
        public AudioClip castSound;
        public AudioClip attackSound;

        public void WalkingSound(int index)
        {
            SoundManagerV2.Instance.PlaySound(walkingSound[index]);
        }
        public void CastingSound()
        {
            SoundManagerV2.Instance.PlaySound(castSound);
        }
        public void AttackSound()
        {
            SoundManagerV2.Instance.PlaySound(attackSound);
        }
    }
}