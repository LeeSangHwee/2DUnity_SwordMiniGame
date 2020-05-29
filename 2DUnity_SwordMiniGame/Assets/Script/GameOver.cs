using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public PlayerCtrl Player_Ctrl;
    public GameObject Canvas_GameOver;
    public GameObject BGM_Mgr;
    private float Delay_fTime;

    void Start()
    {
        Delay_fTime = 0.0f;
        Canvas_GameOver.SetActive(false);
    }

    void Update()
    {
        if (Player_Ctrl.Player_Die == true)
        {
            Delay_fTime += Time.deltaTime;
            BGM_Mgr.SetActive(false);

            if (Delay_fTime >= 0.4f)
                Time.timeScale = 0.0f;
        }            
    }
}
