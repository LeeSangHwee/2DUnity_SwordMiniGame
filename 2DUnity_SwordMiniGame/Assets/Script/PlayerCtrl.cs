using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    enum PLAYER_STATE
    {
        eIdle   ,
        eAttack ,
    }

    public AudioClip[] Sound_SwordSwing = new AudioClip[5];
    private AudioSource Sound_Source;

    public PlayerSwordCol PlayerSword;
    public GameOver GameOverScript;
    public GameObject Player_Obj;
    public Animator Player_Ani;
    private int Player_Dir;
    private int Player_State;
    private float Player_SwordSwingSpd;

    [HideInInspector]
    public bool Player_Die;

    void Start()
    {
        Sound_Source = GetComponent<AudioSource>();

        Player_Dir = 1;
        Player_Die = false;
        Player_State = (int)PLAYER_STATE.eIdle;        
    }

    void Update()
    {
        StartCoroutine(CheckAnimationState());

        if(!Player_Die)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                    Player_Dir = 1;
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                    Player_Dir = -1;

                Player_State = (int)PLAYER_STATE.eAttack;
                Player_Obj.transform.localScale = new Vector3(Player_Dir, 1, 1);
            }

            if (Player_State == (int)PLAYER_STATE.eAttack)
            {
                Player_SwordSwingSpd = 1.0f + ((float)(PlayerSword.iScore / 10) * 0.05f);

                Player_Ani.SetFloat("Swing_fSpeed", Player_SwordSwingSpd);
                Player_Ani.Play("Attack");
                Player_State = (int)PLAYER_STATE.eIdle;

                StartCoroutine(SoundDelayFunc());
            }
        }
    }

    IEnumerator CheckAnimationState()
    {
        while (Player_Ani.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            GameOverScript.Canvas_GameOver.SetActive(true);
            Player_Die = true;

            yield return null;
        }
    }

    IEnumerator SoundDelayFunc()
    {
        yield return new WaitForSeconds(0.3f);

        int Random_Sound = Random.Range(0, 5);

        Sound_Source.clip = Sound_SwordSwing[Random_Sound];
        Sound_Source.PlayOneShot(Sound_Source.clip);
    }
}
