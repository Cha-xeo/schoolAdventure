using SchoolAdventure.Audio;
using SchoolAdventure.Games.Lab.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Lab.Door
{
    public class LabMovement : LabRunes
    {
        [SerializeField] private Sprite[] _shapesSpriteArray;
        private float _timer;
        [SerializeField] private float _submitSpeed;
        [SerializeField] private LabSpinToWin _spinning;
        [SerializeField] private SpriteRenderer _Trail;
        [SerializeField] private LabWheel _wheel;
        [SerializeField] LabGameManager _gameManager;
        [SerializeField] private AudioClip soundEffectHit;
        [SerializeField] private AudioClip soundEffectNoHit;
        public Rune rune;
        bool _parfaitGame = true;
        void Update()
        {
            //Debug.DrawRay(transform.position, -transform.right*5, Color.red);
            if (InputManager.GetInstance().GetSubmitPressed() && _timer + _submitSpeed < Time.time)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, 5f, 1 << 3);
                if (hit.collider != null)
                {
                    if (hit.collider.GetComponent<LabAreaGen>().rune == rune)
                    {
                        SoundManagerV2.Instance.PlaySound(soundEffectHit);
                        _spinning._revSpeed += 45 + _gameManager.currentScene;
                        hit.collider.GetComponent<LabAreaGen>().fadeAway = true;
                        if (!_wheel.removeShape(rune))
                        {
                            morph();
                        }
                        else
                        {
                            if (_parfaitGame)
                            {
                                Success.SuccessHandler.Instance.UnlockAchievment(37);
                            }
                            transform.parent.GetComponent<LabStartGameDoor>().Win();
                        }
                    }
                    else
                    {
                        _parfaitGame = false;
                        SoundManagerV2.Instance.PlaySound(soundEffectNoHit);
                    }
                }
                _spinning._rotDir *= -1f;
                _timer = Time.time;
            }
        }

        private void morph()
        {
            rune = _wheel.TakeRune();
            switch (rune)
            {
                case Rune.Rune1:
                    _Trail.sprite = _shapesSpriteArray[0];
                    break;
                case Rune.Rune2:
                    _Trail.sprite = _shapesSpriteArray[1];
                    break;
                case Rune.Rune3:
                    _Trail.sprite = _shapesSpriteArray[2];
                    break;
                case Rune.Rune4:
                    _Trail.sprite = _shapesSpriteArray[3];
                    break;
                case Rune.Rune5:
                    _Trail.sprite = _shapesSpriteArray[4];
                    break;
                case Rune.Rune6:
                    _Trail.sprite = _shapesSpriteArray[5];
                    break;
                case Rune.Rune7:
                    _Trail.sprite = _shapesSpriteArray[6];
                    break;
                case Rune.Rune8:
                    _Trail.sprite = _shapesSpriteArray[7];
                    break;
                case Rune.Rune9:
                    _Trail.sprite = _shapesSpriteArray[8];
                    break;
                case Rune.Rune10:
                    _Trail.sprite = _shapesSpriteArray[9];
                    break;
                case Rune.Rune11:
                    _Trail.sprite = _shapesSpriteArray[10];
                    break;
                case Rune.Rune12:
                    _Trail.sprite = _shapesSpriteArray[11];
                    break;
                case Rune.Rune13:
                    _Trail.sprite = _shapesSpriteArray[12];
                    break;
                case Rune.Rune14:
                    _Trail.sprite = _shapesSpriteArray[13];
                    break;
                case Rune.Rune15:
                    _Trail.sprite = _shapesSpriteArray[14];
                    break;
                case Rune.Rune16:
                    _Trail.sprite = _shapesSpriteArray[15];
                    break;
                default:
                    break;
            }
        }

        private void OnEnable()
        {
            morph();
        }

        private void OnDisable()
        {
            _timer = 0;
        }
    }
}