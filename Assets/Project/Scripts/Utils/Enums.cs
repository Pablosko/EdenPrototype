using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    public enum Music 
    { 
        rema 
    };

    public enum Effects 
    {
        basicDash,
        dashNoCd,
        returnDash,
        returnDashBack,
        flashDashSlowMotion,
        flashDash
    };

    public enum QuestTypes
    {
        kill,
        gather,
        escort,
        fedX,
        defend,
        profit,
        activate,
        search
    };

    public enum QuestStates
    {
        locked,
        unlocked,
        inProgress,
        completed,
        done,
        canceled
    };
}
