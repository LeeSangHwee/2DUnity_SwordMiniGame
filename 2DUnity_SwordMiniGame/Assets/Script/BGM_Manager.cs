using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Manager : MonoBehaviour
{
    public AudioClip[] Sound_BGM = new AudioClip[2];
    AudioSource Sound_Source;

    void Start()
    {
        Sound_Source = GetComponent<AudioSource>();
        StartCoroutine("PlayMusic");
    }

    IEnumerator PlayMusic()
    {
        Sound_Source.clip = Sound_BGM[0];
        Sound_Source.Play();

        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            if (!Sound_Source.isPlaying)
            {
                Sound_Source.clip = Sound_BGM[1];
                Sound_Source.loop = true;
                Sound_Source.Play();
            }
        }
    }
}
