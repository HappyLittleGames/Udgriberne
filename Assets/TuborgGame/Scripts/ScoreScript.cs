using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    private bool RunningCheck;
    public Text ScoreText;
    private int m_Score = 0;
    public int Score
    {
        get { return FindObjectOfType<Pause>().PlayerScore; }
        set
        {
            FindObjectOfType<Pause>().PlayerScore = value;
            SetScore();
        }
    }


    void Start()
    {
        RunningCheck = FindObjectOfType<Pause>().IsRunning;
        ScoreText = GetComponent<Text>();
        SetScore();
    }

    void SetScore()
    {
        ScoreText.text = "SKORE: " + Score;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Score += 10;
            FindObjectOfType<ScreenShakeScript>().StartShake();

        }
        if (!RunningCheck)
        {
            ScoreText.text = "SKORE: " + Score;
        }
    }
}
