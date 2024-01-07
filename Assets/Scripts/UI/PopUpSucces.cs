using SchoolAdventure.Audio;
using System.Collections;
using TMPro;
using UnityEngine;

namespace SchoolAdventure.UI.PopUp
{
    [System.Serializable]
    /*public class SuccessTemplate
    {
        public string name;
        public ScriptableSuccess success;
    }*/
    public class PopUpSucces : MonoBehaviour
    {
        [SerializeField] AudioClip _successAudioClip;
        [SerializeField] TextMeshProUGUI _successTextMeshProUGUI;
        [SerializeField] TextMeshProUGUI _successDescTextMeshProUGUI;

        public void SetSuccess(ScriptableSuccess Success) 
        {
            _successTextMeshProUGUI.text = Success._name + " débloquer";
            _successDescTextMeshProUGUI.text = Success._description;
        }
        public void PlayAudio()
        {
            SoundManagerV2.Instance.PlaySound( _successAudioClip );
        }
        private void AnimationEnded()
        {
            Destroy(gameObject);
        }
    }
}