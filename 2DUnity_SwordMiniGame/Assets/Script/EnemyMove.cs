using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject Enemy;
    public Animator Enemy_Ani;
    public EnemyState Enemy_state;
    private EnemyManager EnemyMgr;
    [HideInInspector]
    public PlayerSwordCol PlayerSword;
    [HideInInspector]
    public PlayerCtrl Player_Ctrl;
    [HideInInspector]
    public int Enemy_Dir;

    void Start()
    {
        EnemyMgr = GameObject.Find("EnemySystem").GetComponent<EnemyManager>();
        Player_Ctrl = GameObject.Find("Player_SwordMan").GetComponent<PlayerCtrl>();
        PlayerSword = GameObject.Find("Weapon-Sword").GetComponent<PlayerSwordCol>();

        Enemy_Dir = EnemyMgr.Enemy_RandDir;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Enemy_state.Enmey_StateDie)
        {
            if (Enemy_Dir == 0 && Enemy.transform.position.x <= -1.14f)
                Enemy.transform.Translate(Vector2.right * 3.0f * Time.deltaTime * (1.0f + ((float)PlayerSword.iScore / 200.0f)));
            else if (Enemy_Dir == 1 && Enemy.transform.position.x >= 0.61f)
                Enemy.transform.Translate(Vector2.left * 3.0f * Time.deltaTime * (1.0f + ((float)PlayerSword.iScore / 200.0f)));

            if (-1.14f <= Enemy.transform.position.x && Enemy.transform.position.x <= 0.61f)
                Enemy_Ani.Play("Attack");
        }
        else if (Enemy_state.Enmey_StateDie)
            Enemy_Ani.Play("Die");
    }
}
