using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    public Text ScoreText;

    private int m_Score = 0;
    public int Score
    {
        get { return m_Score; }
        set
        {
            m_Score = value;
            SetScore();
        }
    }

    void Start()
    {
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

        }
    }
}
