using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SchoolAdventure.DungeonPuzzle
{
    public enum AltarType
    {
        Player,
        Barril
    }
    public class Altars : MonoBehaviour
    {
        public AltarManager manager;

        public List<SpriteRenderer> runes;
        public float lerpSpeed;
        [SerializeField] TextMeshProUGUI _orderText;
        public AltarType altarType;
        private Color curColor;
        private Color maxColor = new Color(1, 1, 1, 1);
        private Color minColor = new Color(1, 1, 1, 0);

        bool _lerping;
        float _timer;
        public float AltarTimer;
        int _alterId;
        void Activate()
         {
            curColor = maxColor;
            SwapColor();
            Debug.Log("completed");
            if (manager.AltarActivated(_alterId)) 
            {
                GetComponent<Collider2D>().enabled = false;
                enabled = false; 
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (altarType)
            {
                case AltarType.Player:
                    if (collision.CompareTag(Constants.TAG_PLAYER))
                    {
                        _lerping = true;
                    }
                    break;
                case AltarType.Barril:
                    if (collision.CompareTag(Constants.TAG_MATCHINGZONE))
                    {
                        _lerping = true;
                    }
                    break;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            switch (altarType)
            {
                case AltarType.Player:
                    if (collision.CompareTag(Constants.TAG_PLAYER))
                    {
                        _timer = 0;
                        _lerping = false;
                    }
                    break;
                case AltarType.Barril:
                    if (collision.CompareTag(Constants.TAG_MATCHINGZONE))
                    {
                        _timer = 0;
                        _lerping = false;
                    }
                    break;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            switch (altarType)
            {
                case AltarType.Player:
                    if (collision.CompareTag(Constants.TAG_PLAYER))
                    {
                        _timer += Time.deltaTime;
                    }
                    break;
                case AltarType.Barril:
                    if (collision.CompareTag(Constants.TAG_MATCHINGZONE))
                    {
                        _timer += Time.deltaTime;
                    }
                    break;
            }
        }

        void SwapColor()
        {
            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }

        private void Update()
        {
            if (!manager.ready) return;
            curColor = Color.Lerp(curColor, _lerping ? maxColor : minColor, lerpSpeed * Time.deltaTime);
            SwapColor();
            if (_timer >= AltarTimer)
            {
                Activate();
            }
        }

        public void ShowOrder(int i)
        {
            _alterId = i;
            _orderText.text = i.ToString();
            foreach(var r in runes)
            {
                r.color = maxColor;
            }
        }

        public void HideOrder()
        {
            foreach (SpriteRenderer r in runes)
            {
                r.color = minColor;
            }
            _orderText.text = "";
        }
    }
}
