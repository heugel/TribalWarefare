using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score_Caveman : MonoBehaviour {

    public Text scoredisp;
    private int Score = 0;

    public int GetScore() { return Score; }
    public void AddScore(int points)
    {
        Score += points;
        scoredisp.text = "" + Score;
    }


}
