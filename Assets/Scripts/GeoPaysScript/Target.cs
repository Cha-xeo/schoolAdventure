using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Geographie.GeoPays
{
    public class Target : MonoBehaviour
    {
        // 1: Pays  -  2: Capitale  -  3: Continent  -  4: Drapeau
        public int type;
        public int id;
        public string continent;
        private TextMeshProUGUI uiText;
        private Image uiFlag;
        private TextMeshPro selfText;
        private SpriteRenderer selfImage;
        private PlayerMovment player;
        private LifeCount lifeCount;
        private StageGenerator stageGenerator;
        private Score score;

        public void SetUIText(TextMeshProUGUI textMeshProUGUI)
        {
            uiText = textMeshProUGUI;
        }

        public void SetUIFlag(Image imageMeshUI)
        {
            uiFlag = imageMeshUI;
        }

        public void SetIncludes(PlayerMovment pm, LifeCount lc, StageGenerator sg, Score sc)
        {
            player = pm;
            lifeCount = lc;
            stageGenerator = sg;
            score = sc;
        }
        // Start is called before the first frame update
        void Start()
        {
            if (type != 4)
                selfText = GetComponent<TextMeshPro>();
            else
                selfImage = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TargetHit()
        {
            if ((player.currentCountry == -1 && player.currentContinent != "void" && player.currentContinent == continent) || (player.currentCountry == -1 && player.currentContinent == "void") || player.currentCountry == id)
            {
                if (id != -2)
                    player.currentCountry = id;
                player.currentContinent = continent;
            }
            else if ((id == -2 && player.currentContinent != "void" && player.currentContinent != continent) || id != -2)
            {
                if (!(id == -2 && player.currentCountry == -1))
                {
                    if (player.currentCountry == -1)
                        player.countryLeft++;
                    else
                    {
                        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
                        foreach (GameObject target in targets)
                        {
                            Target targetScript = target.GetComponent<Target>();
                            if (targetScript != null && targetScript.id == player.currentCountry)
                            {
                                Destroy(target);
                            }
                        }
                    }
                    lifeCount.LoseLife();
                    stageGenerator.ClearHUD();
                    if (id != -2)
                        player.currentCountry = id;
                    player.currentContinent = continent;
                }

            }
            if (!(id == -2 && player.isContinentKnown))
                player.points++;
            if (id == -2)
                player.isContinentKnown = true;
            // Put Target in HUD
            if (type != 4)
                uiText.text = selfText.text;
            else
                uiFlag.sprite = selfImage.sprite;

            // Destroy Target
            if (player.points == 4)
            {
                score.ScoreUP();
                stageGenerator.ClearHUD();
            }
            if (type != 3)
                Destroy(gameObject);
        }
    }
}