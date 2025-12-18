using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int Score = 0;
    public TMP_Text ScoreCounter;

    public void IncreaseScore()
    {
        Score += 1;
        ScoreCounter.text = $"Score: {Score}";
    }
}
