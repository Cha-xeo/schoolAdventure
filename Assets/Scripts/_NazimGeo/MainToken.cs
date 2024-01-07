using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SchoolAdventure.Games.Geographie.ZouzouGeo
{
    public class MainToken : MonoBehaviour, IPointerClickHandler
    {
        GameObject gameControl;
        SpriteRenderer spriteRenderer;
        public AudioClip flip;
        public Sprite[] faces;
        public Sprite back;
        public int faceIndex;

        public bool isMatched(int index)
        {
            for (int i = 0; i < gameControl.GetComponent<GameControl>().matchedFaces.Count; i++)
            {
                if (gameControl.GetComponent<GameControl>().matchedFaces[i] == index)
                {
                    return (true);
                }
            }
            return (false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Audio.SoundManagerV2.Instance.PlaySound(flip);
            gameControl.GetComponent<GameControl>().CheckMatch();
            if (isMatched(faceIndex) == false)
            {
                if (spriteRenderer.sprite == back)
                {
                    if (gameControl.GetComponent<GameControl>().TwoCaardsUp() == false)
                    {
                        spriteRenderer.sprite = faces[faceIndex];
                        gameControl.GetComponent<GameControl>().AddVisisbleFace(faceIndex);
                        gameControl.GetComponent<GameControl>().CheckMatch();
                    }
                }
                else
                {
                    spriteRenderer.sprite = back;
                    gameControl.GetComponent<GameControl>().RemoveVisibleFace(faceIndex);
                }
            }
        }

        private void Awake()
        {
            // TODO ALED
            gameControl = GameObject.Find("GameControl");
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}