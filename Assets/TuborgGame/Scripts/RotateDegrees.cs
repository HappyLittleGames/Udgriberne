using UnityEngine;
using System.Collections;


public class RotateDegrees : MonoBehaviour {

    [SerializeField] int m_rotationSegments = 8;
    [SerializeField] private float m_segmentSize = 45;
    private float m_currentRot = 0;
    private float m_targetRot = 0;

    [SerializeField] private float m_rotationSpeed = 3;
    [SerializeField] private float m_slowDownFactor = 3;

    void Start()
    {
        m_currentRot = gameObject.transform.eulerAngles.z;
        m_targetRot = m_currentRot;
        m_segmentSize = 360 / m_rotationSegments;
    }

	void FixedUpdate ()
    {
        float rotBeforeDraw = transform.eulerAngles.z;
        m_currentRot = gameObject.transform.eulerAngles.z;
        m_targetRot += FlyTheMoon();
        float speed = m_rotationSpeed * Time.fixedDeltaTime;

        // wighed rotate might actually be really shitty :D::DD

        //transform.Rotate(Vector3.RotateTowards(transform.forward, new Vector3(0f, 0f, m_targetRot), speed, 0f));

        transform.Rotate(new Vector3(0, 0, (WeightedRotate(m_currentRot, m_targetRot, m_slowDownFactor) * speed)));
        //m_targetRot -= WeightedRotate(m_currentRot, m_targetRot, m_slowDownFactor) * speed;

        //transform.Rotate(new Vector3(0, 0, (m_currentRot += m_targetRot)));

        m_targetRot -= transform.eulerAngles.z - rotBeforeDraw;

        if (m_targetRot == m_currentRot)
        {
            Debug.Log("mewn arrievd at targetLoc");
        }
    }

    float FlyTheMoon()
    {
        int direction = GetInputs();

        // coroutine this

        return direction * m_segmentSize;        
    }

    int GetInputs()
    {
        int input = 0;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log(" this is RightArrow");
            input += 1;

            Debug.Log("m_currentRot = " + m_currentRot);
            Debug.Log("m_targetRot = " + (m_targetRot + m_segmentSize));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log(" this is LeftArrow");
            input -= 1;

            Debug.Log("m_currentRot = " + m_currentRot);
            Debug.Log("m_targetRot = " + (m_targetRot - m_segmentSize));
        }
        return input;
    }


    float SmoothstepRotate(float rotation, float interpolant)
    {
        float x = rotation / interpolant;
        return ((x * x) * (3-2*(x))); 

      
    }

    float WeightedRotate(float currentRot, float targetRot, float slowDown)
    {
        return ((currentRot * (slowDown + 1)) + targetRot) / slowDown;
    }
}
