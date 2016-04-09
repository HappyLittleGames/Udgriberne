using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour {

    private float m_thrust = 2.0f;
    public float thrust
    {
        get { return m_thrust; }
        set { m_thrust = value; }
    }

    private Rigidbody m_rigid;
    private CapsuleCollider m_colBox;
    private float m_colTimer = 1f;
    private float m_curColTimer = 0;

    [SerializeField] private AudioClip[] m_audioClips;
    private AudioSource m_audioSource = null;

    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        m_colBox = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        m_rigid.AddForce(transform.up * m_thrust);
        
        if (m_curColTimer < m_colTimer)
        {
            m_curColTimer += Time.fixedDeltaTime;
        }
        else
        {
            EnableCollision();
        }
    }

    private void EnableCollision()
    {
        m_colBox.enabled = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            GetComponentInChildren<GoShootFire>().EnginesOn = false;
            if (thrust > 0)
            {
                FindObjectOfType<ScoreScript>().Score += 10;                
            }
            m_audioSource.Stop();
            // probarbyl spela upp nåt krash å bang?
            thrust = 0;
        }
    }

    void SetupAudio()
    {
        float mod = Random.Range(-0.2f, 0.2f);
        m_audioSource.pitch += mod;
        mod = Random.Range(-0.1f, 0.1f);
        m_audioSource.volume += mod;
    }

    void JetSounds(AudioClip clip, AudioClip startClip, bool loop)
    {
        m_audioSource.clip = clip;
        m_audioSource.loop = loop;

        m_audioSource.PlayOneShot(startClip);
        m_audioSource.Play(); // eller ska dä va wanShots å så?????
    }
}
