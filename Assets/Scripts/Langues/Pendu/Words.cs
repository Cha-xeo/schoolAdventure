using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Langues.Pendu
{
    public class Words
    {
        private List<string> lstWords = new List<string>();
        public string curWord;

        public Words()
        {
            lstWords.Add("SKI");
            lstWords.Add("AVENTURE");
            lstWords.Add("CAROTTE");
            lstWords.Add("ORANGE");
            lstWords.Add("FRUIT");
            lstWords.Add("MANGER");
            lstWords.Add("LUNETTES");
            lstWords.Add("GUITARE");
            lstWords.Add("VENDEUR");
            lstWords.Add("CHEVAL");
            lstWords.Add("ARC EN CIEL");
            lstWords.Add("CHAT");
            lstWords.Add("CHIEN");
            lstWords.Add("SOLEIL");
            lstWords.Add("LUNE");
            lstWords.Add("ETOILE");
            lstWords.Add("FLEUR");
            lstWords.Add("ARBRE");
            lstWords.Add("MAISON");
            lstWords.Add("VOITURE");
            lstWords.Add("AVION");
            lstWords.Add("BATEAU");
            lstWords.Add("POMME");
            lstWords.Add("BANANE");
            lstWords.Add("GATEAU");
            lstWords.Add("BONBON");
            lstWords.Add("LIVRE");
            lstWords.Add("CRAYON");
            lstWords.Add("COULEUR");
            lstWords.Add("PLUIE");
            lstWords.Add("NEIGE");
            lstWords.Add("OISEAU");
            lstWords.Add("POISSON");
            lstWords.Add("LAPIN");
            lstWords.Add("LION");
            lstWords.Add("SINGE");
            lstWords.Add("TIGRE");
            lstWords.Add("GRENOUILLE");
            lstWords.Add("TORTUE");
            lstWords.Add("BALLON");
            lstWords.Add("VELO");
            lstWords.Add("TRAIN");
            lstWords.Add("CAMION");
            lstWords.Add("CANARD");
            lstWords.Add("POULE");
            lstWords.Add("LAPIN");
            lstWords.Add("CHAPEAU");
            lstWords.Add("ROBOT");
        }

        public string GetWord()
        {
            curWord = lstWords[Random.Range(0, lstWords.Count)];
            Debug.Log(curWord);
            return curWord;
        }

        public void delWord(string word)
        {
            lstWords.Remove(word);
        }

        public int lstSize()
        {
            return (lstWords.Count);
        }
    }
}