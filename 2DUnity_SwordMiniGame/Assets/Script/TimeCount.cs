//TimeCount
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public Text timeText;
    public PlayerCtrl Player_Ctrl;
    public StartGame Start_Game;

    [HideInInspector]
    public int imin = 0;

    [HideInInspector]
    public int isec = 0;

    [HideInInspector]
    public int imsec = 0;

    private float fTime;

    void Update()
    {
        if (!Player_Ctrl.Player_Die && Start_Game.GameStart == true)
        {
            fTime += Time.deltaTime;

            if (isec >= 59)
            {
                imin++;
                isec = 0;
            }

            if (imsec >= 99)
            {
                isec++;
                imsec = 0;
                fTime = 0.0f;
            }
            else if (imsec < 99)
                imsec = (int)(fTime * 100);
        }

        timeText.text = string.Format("{0:d2}:{1:d2}:{2:d2}", imin, isec, imsec);
    }
}
