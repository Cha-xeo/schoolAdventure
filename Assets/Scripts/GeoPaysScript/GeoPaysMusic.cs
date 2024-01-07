using SchoolAdventure.Audio;
using System.Collections;
using UnityEngine;

namespace SchoolAdventure.Games.Geographie.GeoPays
{
    public class GeoPaysMusic : MonoBehaviour
    {
        [SerializeField] AudioClip MusicTrack;

        public void PlaySound(AudioClip clip)
        {
            SoundManagerV2.Instance.PlaySound(clip);
        }


        private void Start()
        {
            if (MusicTrack)
            {
                SoundManagerV2.Instance.PlayMusic(MusicTrack);
            }
        }
    }
}