using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour {

    private float m_thrust = 1.0f;
    private Rigidbody m_rigid;

    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        m_rigid.AddRelativeForce(Vector3.up * m_thrust);
    }
}
