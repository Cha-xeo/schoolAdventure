using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

namespace SchoolAdventure.Games.Langues.GenderDetective
{
    public class MatchButton : MonoBehaviour
    {
        public TMP_Text MatchText;
        public TMP_Text ParticleText;
        private GenderWord _word;
        public GenderWord Word { get { return _word; } set { _word = value;  MatchText.text = value.word; ParticleText.text = value.particle; } }
        [SerializeField] Animation _hintAnim;
        [SerializeField] AudioClip ButtonAudioCLip;

        public void PlaySOund()
        {
            Audio.SoundManagerV2.Instance.PlaySound(ButtonAudioCLip);
        }

        public void Pressed()
        {
            if (GameManager.Instance.CheckResponse(Word.gender))
            {
                GameManager.Instance.Cleared();
            }
            else
            {
                GameManager.Instance.Failed();
            }
        }

        public void Hint()
        {
            _hintAnim.Play();
        }
    }
}