using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public PlayerSwordCol PlayerSword;

    void Update()
    {
        ScoreText.text = string.Format("{0:d4}", PlayerSword.iScore);
    }
}
