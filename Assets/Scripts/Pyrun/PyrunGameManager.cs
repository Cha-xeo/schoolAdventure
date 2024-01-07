using SchoolAdventure.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SchoolAdventure.Games.Mathematique.Pyrun
{
    public class PyrunGameManager : MonoBehaviour
    {
        public static PyrunGameManager instance { get; private set; }
        [SerializeField] Player _player;
        [SerializeField] GameObject _gameOverUI;
        [SerializeField] GameObject _game;

        private void Awake()
        {
            if (instance)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        public Player GetPlayer()
        {
            return _player;
        }

        public void GameOver()
        {
            SoundManagerV2.Instance.StopAllSounds();
            _game.SetActive(false);
            _gameOverUI.SetActive(true);
        }
    }
}
