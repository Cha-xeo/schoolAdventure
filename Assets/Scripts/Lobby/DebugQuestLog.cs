using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugQuestLog : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(AddQuest(5));
    }

    private Quest getNext(int i) {
        Quest q = new Quest();
        q.questName = "La course du pirate";
        q.questDescription = "Atteints un score de 80 au pirun au moins 3x et rapporte l'or au vieu pirate, il peut t'aider te donnera de nouveux éléments en cas de réussite.";
        q.expReward = Random.Range(100,1000);
        q.goldReward = Random.Range(5,20);
        q.questCategory = 0;
        q.objective = new Quest.Objective();
        q.objective.type = (Quest.Objective.Type)Random.Range(0,2);
        q.objective.amount = Random.Range(2,10);
        return q;
    }

    private IEnumerator AddQuest(int iter) {
        for (int i = 0; i < iter; i++) {
            QuestLog.AddQuest(getNext(i));
            yield return new WaitForSeconds(3f);
        }
    }
}
