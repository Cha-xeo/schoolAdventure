using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;


namespace SchoolAdventure.Games.Geographie.GeoPays
{
    [System.Serializable]
    public class Country
    {
        public int id;
        public string name;
        public string capitalCity;
        public string continent;
        public Texture2D flagTexture;
    }

    public class StageGenerator : MonoBehaviour
    {
        public GameObject[] stagePrefabs;
        public GameObject textPrefab;
        public GameObject flagPrefab;
        public Country[] countries;
        public TextMeshProUGUI uiText1;
        public TextMeshProUGUI uiText2;
        public TextMeshProUGUI uiText3;
        public Image uiFlag;
        public PlayerMovment player;
        public LifeCount lifeCount;
        public StageGenerator stageGenerator;
        public Score score;

        public void GenerateStage()
        {
            ClearStage();
            GameObject prefab = stagePrefabs[Random.Range(0, stagePrefabs.Length)];
            Vector2 position = new Vector2(0f, 0f);

            GameObject stageElement = Instantiate(prefab, position, Quaternion.identity);
            stageElement.transform.parent = transform;

            GameObject[] slots = stageElement.GetComponentsInChildren<Transform>()
                .Where(child => child.CompareTag("Slot"))
                .Select(child => child.gameObject)
                .ToArray();
            List<Vector2> slotPositions = new List<Vector2>();
            slotPositions.Clear();
            // Access the "slot" game objects and their positions
            foreach (GameObject slot in slots)
            {
                Vector2 slotPosition = slot.transform.position;
                slotPositions.Add(slotPosition);
            }

            // Set the text Continent
            foreach (string continent in new string[] { "Afrique", "Europe", "Asie", "Amérique" })
            {
                GameObject newtextPrefab = Instantiate(textPrefab, stageElement.transform);
                TextTargetScript textSetter = newtextPrefab.GetComponent<TextTargetScript>();

                textSetter.SetText(continent);

                Target targetComponent = newtextPrefab.AddComponent<Target>();
                targetComponent.type = 3;
                targetComponent.SetUIText(uiText3);
                targetComponent.id = -2;
                targetComponent.continent = continent;
                targetComponent.SetIncludes(player, lifeCount, stageGenerator, score);

                // Position the text prefab in a random slot
                int randomSlotIndex = Random.Range(0, slotPositions.Count);
                newtextPrefab.transform.position = slotPositions[randomSlotIndex];
                slotPositions.RemoveAt(randomSlotIndex);
            }

            HashSet<int> selectedIndices = new HashSet<int>();
            // Select the random countries
            while (selectedIndices.Count < slotPositions.Count / 3)
            {
                if (slotPositions.Count / 3 > countries.Length)
                {
                    Debug.Log("Number of unique countries is less than the desired count. Exiting loop.");
                    break;
                }
                int randomIndex = Random.Range(0, countries.Length);
                selectedIndices.Add(randomIndex);
            }
            player.countryLeft = slotPositions.Count / 3;
            // Instantiate text prefabs and set the text dynamically
            foreach (int selectedIndex in selectedIndices)
            {
                // Set the text Country Name
                GameObject newtextPrefab = Instantiate(textPrefab, stageElement.transform);
                TextTargetScript textSetter = newtextPrefab.GetComponent<TextTargetScript>();

                textSetter.SetText(countries[selectedIndex].name);

                Target targetComponent = newtextPrefab.AddComponent<Target>();
                targetComponent.type = 1;
                targetComponent.SetUIText(uiText1);
                targetComponent.id = countries[selectedIndex].id;
                targetComponent.continent = countries[selectedIndex].continent;
                targetComponent.SetIncludes(player, lifeCount, stageGenerator, score);

                // Position the text prefab in a random slot
                int randomSlotIndex = Random.Range(0, slotPositions.Count);
                newtextPrefab.transform.position = slotPositions[randomSlotIndex];
                slotPositions.RemoveAt(randomSlotIndex);

                // Set the text Capital City
                newtextPrefab = Instantiate(textPrefab, stageElement.transform);
                textSetter = newtextPrefab.GetComponent<TextTargetScript>();

                textSetter.SetText(countries[selectedIndex].capitalCity);

                targetComponent = newtextPrefab.AddComponent<Target>();
                targetComponent.type = 2;
                targetComponent.SetUIText(uiText2);
                targetComponent.id = countries[selectedIndex].id;
                targetComponent.continent = countries[selectedIndex].continent;
                targetComponent.SetIncludes(player, lifeCount, stageGenerator, score);

                randomSlotIndex = Random.Range(0, slotPositions.Count);
                newtextPrefab.transform.position = slotPositions[randomSlotIndex];
                slotPositions.RemoveAt(randomSlotIndex);

                //Set Flag
                GameObject newFlagPrefab = Instantiate(flagPrefab, stageElement.transform);
                SpriteRenderer spriteRenderer = newFlagPrefab.GetComponent<SpriteRenderer>();
                Sprite Sprite = Sprite.Create(countries[selectedIndex].flagTexture, new Rect(0, 0, countries[selectedIndex].flagTexture.width, countries[selectedIndex].flagTexture.height), new Vector2(0.5f, 0.5f));
                spriteRenderer.sprite = Sprite;

                targetComponent = newFlagPrefab.AddComponent<Target>();
                targetComponent.type = 4;
                targetComponent.SetUIFlag(uiFlag);
                targetComponent.id = countries[selectedIndex].id;
                targetComponent.continent = countries[selectedIndex].continent;
                targetComponent.SetIncludes(player, lifeCount, stageGenerator, score);

                randomSlotIndex = Random.Range(0, slotPositions.Count);
                newFlagPrefab.transform.position = slotPositions[randomSlotIndex];
                slotPositions.RemoveAt(randomSlotIndex);
            }
        }

        private void ClearStage()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            ClearHUD();
        }

        public void ClearHUD()
        {
            uiText1.text = "";
            uiText2.text = "";
            uiText3.text = "";
            Texture2D flagTexture = Resources.Load<Texture2D>("Countries/empty");
            uiFlag.sprite = Sprite.Create(flagTexture, new Rect(0, 0, flagTexture.width, flagTexture.height), new Vector2(0.5f, 0.5f));
            player.currentCountry = -1;
            player.currentContinent = "void";
            player.points = 0;
            player.countryLeft--;
            player.isContinentKnown = false;
        }

        public void InitializeCountries()
        {
            // Initialize the countries array with the desired data
            countries = new Country[]
            {
            new Country
            {
                id = 0,
                name = "Algérie",
                capitalCity = "Alger",
                continent = "Afrique",
                flagTexture = Resources.Load<Texture2D>("Countries/algeria")
            },
            new Country
            {
                id = 1,
                name = "Argentine",
                capitalCity = "Buenos Aires",
                continent = "Amérique",
                flagTexture = Resources.Load<Texture2D>("Countries/argentin")
            },
            new Country
            {
                id = 2,
                name = "Autriche",
                capitalCity = "Vienne",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/austria")
            },
            new Country
            {
                id = 3,
                name = "Belgique",
                capitalCity = "Bruxelle",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/belgium")
            },
            new Country
            {
                id = 4,
                name = "Brésil",
                capitalCity = "Brazillia",
                continent = "Amérique",
                flagTexture = Resources.Load<Texture2D>("Countries/brazil")
            },
            new Country
            {
                id = 5,
                name = "Cameroun",
                capitalCity = "Yaoundé",
                continent = "Afrique",
                flagTexture = Resources.Load<Texture2D>("Countries/cameroon")
            },
            new Country
            {
                id = 6,
                name = "Canada",
                capitalCity = "Ottawa",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/canada")
            },
            new Country
            {
                id = 7,
                name = "Chine",
                capitalCity = "Pékin",
                continent = "Asie",
                flagTexture = Resources.Load<Texture2D>("Countries/china")
            },
            new Country
            {
                id = 8,
                name = "Congo",
                capitalCity = "Brazzaville",
                continent = "Afrique",
                flagTexture = Resources.Load<Texture2D>("Countries/congo")
            },
            new Country
            {
                id = 9,
                name = "Danemark",
                capitalCity = "Copenhague",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/denmark")
            },
            new Country
            {
                id = 10,
                name = "Egypte",
                capitalCity = "Le Caire",
                continent = "Afrique",
                flagTexture = Resources.Load<Texture2D>("Countries/egypt")
            },
            new Country
            {
                id = 11,
                name = "Finlande",
                capitalCity = "Helsinki",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/finland")
            },
            new Country
            {
                id = 12,
                name = "France",
                capitalCity = "Paris",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/france")
            },
            new Country
            {
                id = 13,
                name = "Allemange",
                capitalCity = "Berlin",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/germany")
            },
            new Country
            {
                id = 14,
                name = "Grèce",
                capitalCity = "Athènes",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/greece")
            },
            new Country
            {
                id = 15,
                name = "Irlande",
                capitalCity = "Dublin",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/ireland")
            },
            new Country
            {
                id =16 ,
                name = "Italie",
                capitalCity = "Rome",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/italy")
            },
            new Country
            {
                id = 17,
                name = "Côte d'ivoire",
                capitalCity = "Yamoussoukro",
                continent = "Afrique",
                flagTexture = Resources.Load<Texture2D>("Countries/ivory")
            },
            new Country
            {
                id = 18,
                name = "Jamaïque",
                capitalCity = "Kingston",
                continent = "Amérique",
                flagTexture = Resources.Load<Texture2D>("Countries/jamaica")
            },
            new Country
            {
                id = 19,
                name = "Japon",
                capitalCity = "Tokyo",
                continent = "Asie",
                flagTexture = Resources.Load<Texture2D>("Countries/japan")
            },
            new Country
            {
                id = 20,
                name = "Mali",
                capitalCity = "Bamako",
                continent = "Afrique",
                flagTexture = Resources.Load<Texture2D>("Countries/mali")
            },
            new Country
            {
                id = 21,
                name = "Mexique",
                capitalCity = "Mexico",
                continent = "Amérique",
                flagTexture = Resources.Load<Texture2D>("Countries/mexico")
            },
            new Country
            {
                id = 22,
                name = "Maroc",
                capitalCity = "Rabat",
                continent = "Afrique",
                flagTexture = Resources.Load<Texture2D>("Countries/morocco")
            },
            new Country
            {
                id = 23,
                name = "Pays-Bas",
                capitalCity = "Amsterdam",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/netherland")
            },
            new Country
            {
                id = 24,
                name = "Norvège",
                capitalCity = "Oslo",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/norway")
            },
            new Country
            {
                id = 25,
                name = "Pérou",
                capitalCity = "Lima",
                continent = "Amérique",
                flagTexture = Resources.Load<Texture2D>("Countries/peru")
            },
            new Country
            {
                id = 26,
                name = "Pologne",
                capitalCity = "Varsovie",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/poland")
            },
            new Country
            {
                id = 27,
                name = "Portugal",
                capitalCity = "Lisbonne",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/portugal")
            },
            new Country
            {
                id = 282,
                name = "Sénégal",
                capitalCity = "Dakar",
                continent = "Afrique",
                flagTexture = Resources.Load<Texture2D>("Countries/senegal")
            },
            new Country
            {
                id = 29,
                name = "Corée du Sud",
                capitalCity = "Séoul",
                continent = "Asie",
                flagTexture = Resources.Load<Texture2D>("Countries/skorea")
            },
            new Country
            {
                id = 30,
                name = "Espagne",
                capitalCity = "Madrid",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/spain")
            },
            new Country
            {
                id = 31,
                name = "Suède",
                capitalCity = "Stockholm",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/sweden")
            },
            new Country
            {
                id = 32,
                name = "Suisse",
                capitalCity = "Berne",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/switzlnd")
            },
            new Country
            {
                id = 33,
                name = "Thaïlande",
                capitalCity = "Bangkok",
                continent = "Asie",
                flagTexture = Resources.Load<Texture2D>("Countries/thailand")
            },
            new Country
            {
                id = 34,
                name = "Tunisie",
                capitalCity = "Tunis",
                continent = "Afrique",
                flagTexture = Resources.Load<Texture2D>("Countries/tunisia")
            },
            new Country
            {
                id = 35,
                name = "Turquie",
                capitalCity = "Ankara",
                continent = "Asie",
                flagTexture = Resources.Load<Texture2D>("Countries/turkey")
            },
            new Country
            {
                id = 36,
                name = "Royaume-Uni",
                capitalCity = "Londre",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/uk")
            },
            new Country
            {
                id = 37,
                name = "Ukraine",
                capitalCity = "Kiev",
                continent = "Europe",
                flagTexture = Resources.Load<Texture2D>("Countries/ukraine")
            },
            new Country
            {
                id = 38,
                name = "Uruguay",
                capitalCity = "Montevideo",
                continent = "Amérique",
                flagTexture = Resources.Load<Texture2D>("Countries/uruguay")
            },
            new Country
            {
                id = 39,
                name = "Etats-Unis",
                capitalCity = "Washington",
                continent = "Amérique",
                flagTexture = Resources.Load<Texture2D>("Countries/usa")
            },
            new Country
            {
                id = 40,
                name = "Vénézuela",
                capitalCity = "Caracas",
                continent = "Amérique",
                flagTexture = Resources.Load<Texture2D>("Countries/venezuel")
            },
            new Country
            {
                id = 41,
                name = "Vietnam",
                capitalCity = "Hanoï",
                continent = "Asie",
                flagTexture = Resources.Load<Texture2D>("Countries/vietnam")
            },
                // Add more country objects as needed
            };
        }
    }
}