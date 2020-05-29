using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordCol : MonoBehaviour
{
    public AudioClip[] Sound_SwordHit = new AudioClip[5];
    public AudioClip[] Sound_SwordSwing = new AudioClip[5];
    private AudioSource Sound_Source;

    [HideInInspector]
    public Animator Player_Ani;
    public Animator Enemy_Ani;
    [HideInInspector]
    public Transform PlayerObj;
    public EnemyMove Enemy_Move;

    private bool State_PlayerDie = false;

    void Start()
    {
        Sound_Source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(CheckAnimationState());

            if (State_PlayerDie == true)
            {
                PlayerObj = GameObject.Find("Player_SwordMan").GetComponent<Transform>();
                Enemy_Move = GetComponentInParent<EnemyMove>();

                if(Enemy_Move.Enemy_Dir == 0)
                    PlayerObj.transform.localScale = new Vector3(1, 1, 1);
                else if (Enemy_Move.Enemy_Dir == 1)
                    PlayerObj.transform.localScale = new Vector3(-1, 1, 1);

                int Random_Sound = Random.Range(0, 5);

                Sound_Source.clip = Sound_SwordHit[Random_Sound];
                Sound_Source.PlayOneShot(Sound_Source.clip);
                Sound_Source.clip = Sound_SwordSwing[Random_Sound];
                Sound_Source.PlayOneShot(Sound_Source.clip);

                Player_Ani = collision.GetComponent<Animator>();
                Player_Ani.Play("Die");
            }                
        }
    }

    IEnumerator CheckAnimationState()
    {
        while (Enemy_Ani.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            if(Enemy_Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.65f)
                State_PlayerDie = true;

            yield return null;
        }        
    }
}
