using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Gameplay.UI
{
    public class VideoSettings : MonoBehaviour
    {
       // [SerializeField] Sprite[] _toggleImage;
        [SerializeField] Toggle _toggle;
        bool _shouldActivate = false;
        [SerializeField] TMP_Dropdown _resolutionDropdonwn;
        Resolution[] _resolutions;

        private void Start()
        {
            _resolutions = Screen.resolutions;
            _resolutionDropdonwn.ClearOptions();
            List<string> options = new List<string>();
            int length = _resolutions.Length;
            int currentIndex = 0;
            for (int i = 0; i < length; i++)
            {
                options.Add(_resolutions[i].width + " x " + _resolutions[i].height);
                if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
                {
                    currentIndex = i;
                }
            }
            _resolutionDropdonwn.AddOptions(options);
            Debug.Log(Screen.currentResolution.ToString());
            _resolutionDropdonwn.value = currentIndex;
            _resolutionDropdonwn.RefreshShownValue();
            _toggle.isOn = Screen.fullScreen;
            _shouldActivate = true;
        }
        public void SetFullScreen(bool IsFullScreen)
        {
            if (!_shouldActivate) return;
            Screen.fullScreen = IsFullScreen;
           // _toggle.image.sprite = _toggleImage[IsFullScreen ? 0 : 1];
        }

        public void SetResolution(int resolutionIndex)
        {
            if (!_shouldActivate) return;
            //if (Screen.currentResolution.width == _resolutions[resolutionIndex].width && Screen.currentResolution.height == _resolutions[resolutionIndex].height) return;
            Screen.SetResolution(_resolutions[resolutionIndex].width, _resolutions[resolutionIndex].height, Screen.fullScreen);
        }
        private void OnEnable()
        {
            //_toggle.isOn = Screen.fullScreen;
            //_toggle.image.sprite = _toggleImage[_toggle.isOn ? 0 : 1];
        }
    }
}