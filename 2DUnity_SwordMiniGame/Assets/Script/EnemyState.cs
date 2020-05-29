using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [HideInInspector]
    public bool Enmey_StateDie = false;
    [HideInInspector]
    public float Destroy_fTime = 0.0f;

    void Update()
    {
        if (Enmey_StateDie)
        {
            Destroy_fTime += Time.deltaTime;

            if (Destroy_fTime >= 1.5f)
                Destroy(GameObject.Find("Enemy"));
        }
    }
}
