using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerCtrl Player_Ctrl;
    public GameObject EnemyObj;
    public GameObject Prefab_Enemy;
    private float fNowframe;
    public float fMaxframe;

    [HideInInspector]
    public int Enemy_RandDir;

    void Start()
    {
        fMaxframe = 3.0f;
        fNowframe = fMaxframe;
    }

    void Update()
    {
        if (!Player_Ctrl.Player_Die)
        {
            fNowframe += Time.deltaTime;

            if (fNowframe >= fMaxframe)
            {
                Enemy_RandDir = Random.RandomRange(0, 2);
                GameObject Enemy = MonoBehaviour.Instantiate(Prefab_Enemy) as GameObject;

                if (Enemy_RandDir == 0)
                {
                    Enemy.name = "Enemy";
                    Enemy.transform.localPosition = new Vector3(-9.81f, -3.642f, 0.0f);
                    Enemy.transform.localScale = new Vector3(-0.8f, 0.8f, 1.0f);
                    Enemy.transform.parent = EnemyObj.transform;
                }
                else if (Enemy_RandDir == 1)
                {
                    Enemy.name = "Enemy";
                    Enemy.transform.localPosition = new Vector3(9.81f, -3.642f, 0.0f);
                    Enemy.transform.localScale = new Vector3(0.8f, 0.8f, 1.0f);
                    Enemy.transform.parent = EnemyObj.transform;
                }

                fNowframe = 0.0f;
            }
        }         
    }
}
