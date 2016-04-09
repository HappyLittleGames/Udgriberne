using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour {

    private float m_thrust = 2.0f;
    private Rigidbody m_rigid;
    private CapsuleCollider m_colBox;
    private float m_colTimer = 1f;
    private float m_curColTimer = 0;

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
            m_thrust = 0;
        }
    }
}
