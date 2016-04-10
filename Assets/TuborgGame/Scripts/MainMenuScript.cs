using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] AudioClip[] m_audioClips;
    private AudioSource m_audioSource;

    

    void Start()
    {
        m_audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void StartKey()
    {
        m_audioSource.PlayOneShot(m_audioClips[0]);
        UnityEngine.SceneManagement.SceneManager.LoadScene("HedmansScene");

    }

    public void OnMouseEnter()
    {
        
        m_audioSource.PlayOneShot(m_audioClips[2], 0.3f);
        
        Debug.Log("hovhands");
    }

    public void StopKey()
    {
        m_audioSource.PlayOneShot(m_audioClips[1]);
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

}
