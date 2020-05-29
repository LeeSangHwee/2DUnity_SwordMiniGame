using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{    
    public GameObject Button_GameStart;
    public GameObject BGM_Mgr;
    [HideInInspector]
    public bool GameStart = false;

    void Awake()
    {
        Time.timeScale = 0.0f;
    }

    public void OnClickFunc()
    {
        Time.timeScale = 1.0f;

        Button_GameStart.SetActive(false);
        BGM_Mgr.SetActive(true);
        GameStart = true;
    }
}
