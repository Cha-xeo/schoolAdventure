    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Lab.Door
{
    public class LabAreaGen : LabRunes
    {
        public Rune rune;
        private Material _mat;
        private Transform _childTransform;
        public bool fadeAway = false;
        private bool _isFadeAway = false;

        private void Start()
        {
            _mat = GetComponent<SpriteRenderer>().material;
            _childTransform = transform.GetChild(0).transform;
            _childTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 360 - transform.rotation.z));
        }
        private void Update()
        {
            if (fadeAway)
            {
                if (!_isFadeAway)
                {
                    _isFadeAway = true;
                    transform.gameObject.tag = "MatchingZoneFadded";
                    StartCoroutine(fade());
                    //Destroy(gameObject, 2f);
                }
                _mat.SetFloat("_Fade", Mathf.Lerp(_mat.GetFloat("_Fade"), 0f, 2f * Time.deltaTime));
                //_matChild.SetFloat("_Fade", Mathf.Lerp(_matChild.GetFloat("_Fade"), 0f, 2f * Time.deltaTime));
            }
        }

        private IEnumerator fade()
        {
            yield return new WaitForSeconds(2f);
            fadeAway = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        /*public void SetFadeAway()
        {
            GetComponent<SpriteRenderer>().enabled= false;
            _matChild.SetFloat("_Fade", 0.5f);
            transform.gameObject.tag = "MatchingZoneFadded";
        }*/
    }
}