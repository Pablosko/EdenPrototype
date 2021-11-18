using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateManagers : MonoBehaviour
{
    private void Awake()
    {
        AudioController.InstanceAudio.LoadAllFx();
        GameController.Instance.ActivateGameCon();
    }
}
