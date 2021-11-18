using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public Quest[] quests = new Quest[2];

    void Start()
    {
        DDBBManager.LoadQuestData(quests);
        for (int i = 0; i < quests.Length; i++)
        {
            quests[i].goal.Initialize(quests[i].questInfo.description, 10);
        }
    }

    void Update()
    {
       
    }

    //TEMPORAL
    public string GetMisionInfo(int id)
    {
       return quests[id].questInfo.description;
    }
}
