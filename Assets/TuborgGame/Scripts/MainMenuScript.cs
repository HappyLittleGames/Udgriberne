using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public void StartKey()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HedmansScene");
    }

    public void StopKey()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
