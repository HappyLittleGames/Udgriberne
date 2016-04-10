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

    private float m_destroyTime;
    public float DestroyTime
    {
        set { m_destroyTime = value; }
    }

    [SerializeField] private Object[] m_timeoutDestroySprite;

    [SerializeField] private AudioClip[] m_audioClips;
    private AudioSource m_audioSource = null;

    void Start()
    {
  
        m_rigid = GetComponent<Rigidbody>();
        m_colBox = GetComponent<CapsuleCollider>();
        StartCoroutine(SelfDestruct(m_destroyTime));

        SetupAudio();
        JetSounds(m_audioClips[0], true);
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

    private IEnumerator SelfDestruct(float time)
    {
        yield return new WaitForSeconds(time);
        
        for (int i = 0; i < m_timeoutDestroySprite.Length; i++)
        {
            GameObject explosion = Instantiate(m_timeoutDestroySprite[i], transform.position, transform.rotation) as GameObject;

            SelfDestructor selfDest = explosion.AddComponent<SelfDestructor>();
            selfDest.DestructTime = 0.5f;
        }
       
        Destroy(gameObject);
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
                FindObjectOfType<ScreenShakeScript>().StartShake();
            }

            thrust = 0;
            //m_audioSource.Stop();
            // probarbyl spela upp nåt krash å bang?
            
        }
    }

    void SetupAudio()
    {
        m_audioSource = GetComponent<AudioSource>();
        float mod = Random.Range(-0.1f, 0.40f);
        m_audioSource.pitch += mod;
        mod = Random.Range(-0.1f, 0.1f);
        //m_audioSource.volume += mod;

    }

    void JetSounds(AudioClip clip, /*AudioClip startClip,*/ bool loop)
    {
        m_audioSource.clip = clip;
        m_audioSource.loop = loop;

        //m_audioSource.PlayOneShot(startClip);
        m_audioSource.Play(); // eller ska dä va wanShots å så?????
    }
}
