using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordCol : MonoBehaviour
{
    [HideInInspector]
    public EnemyState Enemy_state;
    public Animator Player_Ani;
    public EnemyManager EnemyMgr;
    public AudioClip[] Sound_SwordHit = new AudioClip[5];
    AudioSource Sound_Source;

    [HideInInspector]
    public int iScore = 0;
    [HideInInspector]
    public bool State_EnemyDie = false;
    
    void Start()
    {
        Sound_Source = GetComponent<AudioSource>();        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy_state = collision.GetComponent<EnemyState>();

            if (!Enemy_state.Enmey_StateDie)
            {
                StartCoroutine(CheckAnimationState());

                if (Enemy_state.Enmey_StateDie)
                {
                    iScore += 10;

                    if (EnemyMgr.fMaxframe > 0.5f)
                        EnemyMgr.fMaxframe -= 0.1f;

                    int Random_Sound = Random.Range(0, 5);
                    Sound_Source.clip = Sound_SwordHit[Random_Sound];
                    Sound_Source.PlayOneShot(Sound_Source.clip);
                }
            }
        }
    }

    IEnumerator CheckAnimationState()
    {
        while (Player_Ani.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.41f)
        {
            if (Player_Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.65f)
                Enemy_state.Enmey_StateDie = true;

            yield return null;
        }
    }
}
