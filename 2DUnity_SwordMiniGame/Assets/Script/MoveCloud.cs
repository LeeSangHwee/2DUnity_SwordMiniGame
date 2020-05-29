using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    public PlayerCtrl Player_Ctrl;
    public GameObject[] Cloud_Obj = new GameObject[2];

    void Update()
    {
        if (!Player_Ctrl.Player_Die)
        {
            for (int i = 0; i < 2; ++i)
            {
                Cloud_Obj[i].transform.Translate(Vector2.right * 1.0f * Time.deltaTime);

                if (Cloud_Obj[i].transform.localPosition.x >= 29.5f)
                    Cloud_Obj[i].transform.localPosition = new Vector3(-32.35f, 4.9f, 101.0244f);
            }
        }
    }
}
