using UnityEngine;
using System.Collections;


public class GoShootFire : MonoBehaviour
{
    [SerializeField] private float m_flareSize = 0.1f;
    [SerializeField] private Object[] m_rocketFlares;
    private bool m_spouting = true;
    [SerializeField] private float m_flareSpeed = 0.05f;
    [SerializeField] private float m_scaleFactor = 0.2f;
    private float m_timePassed = 0;

    private bool m_enginesOn = true; 
    public bool EnginesOn { set { m_enginesOn = value; } }

    [SerializeField] private AudioClip[] m_audioClips;
    private AudioSource m_audioSource = null;

    void Start()
    {
        m_audioSource = gameObject.AddComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (m_enginesOn)
        {
            m_timePassed += Time.fixedDeltaTime;
            if (m_timePassed > m_flareSpeed)
            {
                m_timePassed = 0f;
                float offsetter = Random.Range((m_flareSize * 2 - m_scaleFactor), (m_flareSize * 2 + m_scaleFactor));
                GameObject flare = (GameObject)Instantiate(m_rocketFlares[Random.Range(0, m_rocketFlares.Length)], transform.position, transform.rotation);

                flare.transform.position += new Vector3(0f, offsetter / 20, 0f);
                flare.transform.localScale = new Vector3(Random.Range(m_flareSize, (m_flareSize + m_scaleFactor / 3)), m_flareSize, offsetter);

                SelfDestructor selfDestructor = flare.AddComponent<SelfDestructor>(); //Selfdestructor thoe!!
                selfDestructor.DestructTime = m_flareSpeed;
            }
        }
    }

    void JetSounds(AudioClip clip, AudioClip startClip, bool loop)
    {
        m_audioSource.clip = clip;
        float mod = Random.Range(-0.2f, 0.2f);
        m_audioSource.pitch += mod;
        mod = Random.Range(-0.1f, 0.1f);
        m_audioSource.volume += mod;
        m_audioSource.loop = loop;

        m_audioSource.PlayOneShot(startClip);
        m_audioSource.Play(); // eller ska dä va wanShots å så?????
    }
}
