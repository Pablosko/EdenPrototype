using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public CinemachineConfiner cameraConfiner;
    public ObjectsManager objectsManager;

    public PlayerController player;
    public HudController hud;

    public static GameController Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("Game Manager");
                go.AddComponent<GameController>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        _instance = this;
        
    }
    void Start()
    {
    }

    void Update()
    {
        
    }

    public void ActivateGameCon()
    {
    }

    private void OnDestroy()
    {
        if(_instance == this)
        {
            _instance = null;
        }
    }
}
