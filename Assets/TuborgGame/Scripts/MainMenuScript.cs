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
        m_audioSource.PlayOneShot(m_audioClips[0], 0.05f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("HedmansScene");

    }

    public void OnMouseEnter()
    {
        
        m_audioSource.PlayOneShot(m_audioClips[2], 0.3f);
    }

    public void StopKey()
    {
        m_audioSource.PlayOneShot(m_audioClips[1], 0.05f);
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

}
