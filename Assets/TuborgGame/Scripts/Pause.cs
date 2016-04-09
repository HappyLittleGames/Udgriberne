using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    

    private bool m_IsPaused = false;
    public bool IsPaused
    {
        get { return m_IsPaused; }
        set
        {
            m_IsPaused = value;
            Cursor.visible = value;
            if (m_IsPaused)
            {
                Time.timeScale = 0;
                FindObjectOfType<Camera>().fieldOfView = 40;
            }
            else
            {
                Time.timeScale = 1;
                FindObjectOfType<Camera>().fieldOfView = 60;
            }
        }

    }

    GameObject PauseMenuReff;

    void Start()
    {
        PauseMenuReff = FindObjectOfType<PauseMenu>().gameObject;
        PauseMenuReff.SetActive(false);
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseFunc();
        }
	}
    
    public void PauseFunc()
    {
        IsPaused = !IsPaused;
        PauseMenuReff.SetActive(IsPaused);
    }

    public void QuitFunc()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
