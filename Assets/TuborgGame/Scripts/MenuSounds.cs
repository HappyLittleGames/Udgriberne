using UnityEngine;
using System.Collections;

public class MenuSounds : MonoBehaviour {

    [SerializeField] AudioClip[] m_audioClips;
    private AudioSource m_audioSource;

    void Start()
    {
        m_audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void StartKey()
    {
        m_audioSource.PlayOneShot(m_audioClips[0], 0.05f);
 
    }

    public void OnMouseEnter()
    {

        m_audioSource.PlayOneShot(m_audioClips[2], 0.05f);

        Debug.Log("hovhands");
    }

    public void StopKey()
    {
        m_audioSource.PlayOneShot(m_audioClips[1], 0.05f);
    }
}

