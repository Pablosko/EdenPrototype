using UnityEngine;

public static class DDBBManager
{
    public static void LoadQuestData(Quest[] _quests)
    {
        for (int i = 0; i < _quests.Length; i++)
        {
            _quests[i].questInfo = JsonUtility.FromJson<Info>(FileManager.LoadJSONFile(i.ToString()));
        }
    }
}
