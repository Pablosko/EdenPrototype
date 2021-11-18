
using UnityEngine;

[System.Serializable]
public struct Info
{
    public int id;
    public Enums.QuestTypes type;
    public Enums.QuestStates state;
    public string questName;
    public string description;
    public bool isCompleted;
}
[System.Serializable]

public struct Goal
{
    string description;
    int currentAmount;
    int requiredAmount;
    bool completed;

    public void Initialize(string desc, int rAmount)
    {
        completed = false;
        currentAmount = 0;
        description = desc;
        requiredAmount = rAmount;
    }

    void Evaluate()
    {
        //Check how is it going the current Goal
    }
    public void SetCompleted()
    {
        completed = true;
    }
    public string GetDescription()
    {
        return description;
    }
    public int GetAmount()
    {
        return currentAmount;
    }
    public int GetRequiredAmount()
    {
        return requiredAmount;
    }
}
[System.Serializable]
public class Quest
{
    public Info questInfo;
    public Goal goal;

    /*
    public void OnGoalCompleted()
    {
        goal.SetCompleted();
    }
    */
    public void CheckGoals()
    {
        if(goal.GetAmount() >= goal.GetRequiredAmount())
        {
            goal.SetCompleted();
        }
    }
    public void GiveReward()
    {
        //RewardPlayer
    }
}

