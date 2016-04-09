using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AngularMovement : MonoBehaviour {

    [SerializeField] Object m_targetObject;
    [SerializeField] float m_rotSpeed = 5f;
    [SerializeField] int m_rotationSegments = 8;
    //[SerializeField] private float m_segmentSize = 45f;
    [SerializeField] private float m_delayTime = 0.5f;
    private bool m_isMoving = false;
    private bool m_isTraversing = false;
    private List<float> m_rotTargets = new List<float>();
    private GameObject[] m_rotObjects;

    private int m_rotIndex = 0;

    void Start ()
    {
        m_rotObjects = new GameObject[m_rotationSegments];

        for (int i = 0; i < m_rotationSegments; i++)
        {
            m_rotTargets.Add((360 / m_rotationSegments) * i);
        }
        for (int i = 0; i < m_rotationSegments; i++)
        {
            m_rotObjects[i] = (GameObject)Instantiate(m_targetObject);
            m_rotObjects[i].gameObject.transform.Rotate(0f, 0f, m_rotTargets[i]);
        }
    }

    void FixedUpdate()
    {
        //float speed = m_rotSpeed * Time.fixedDeltaTime;
        //float speed = (Mathf.Abs(transform.rotation.eulerAngles.z - m_rotObjects[m_rotIndex].transform.rotation.eulerAngles.z)) / m_rotSpeed;

        //transform.rotation = Quaternion.Euler(Vector3.RotateTowards(transform.rotation.eulerAngles, new Vector3(0, 0, m_rotTargets[m_rotIndex]), speed, 1f));
        
        float speed = Quaternion.Angle(transform.rotation, m_rotObjects[m_rotIndex].transform.rotation) * (m_rotSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, m_rotObjects[m_rotIndex].transform.rotation, speed);

        if (m_isTraversing)
        {
            float amount = (180 / ( m_delayTime * 2)) * Time.fixedDeltaTime;
            transform.Rotate(new Vector3(amount, 0 , 0));
        }
    }

    void Update()
    {
        FlyTheMoon();

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(FlipSides());
        }
    }

    float FlyTheMoon()
    {
        int direction = GetInputs();

        // coroutine this
        if (!m_isMoving && direction != 0)  
        {
            StartCoroutine(ExecuteMove(direction));
        }
        return 0;
    }

    int GetInputs()
    {
        int input = 0;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log(" this is RightArrow");
            input += 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log(" this is LeftArrow");
            input -= 1;
        }
        return input;
    }

    private IEnumerator FlipSides()
    {
        m_isMoving = true;
        m_isTraversing = true;

        if (m_rotIndex >= 4)
        {
            m_rotIndex -= 4;
        }
        else
        {
            m_rotIndex += 4;
        }
        yield return new WaitForSeconds(m_delayTime*2);

        m_isMoving = false;
        m_isTraversing = false;
    }

    private IEnumerator ExecuteMove(int direction)
    {
        if (m_rotIndex == (m_rotationSegments - 1) && direction > 0)
        {
            m_rotIndex = 0;
        }
        else if (m_rotIndex == 0 && direction < 0)
        {
            m_rotIndex += (m_rotationSegments - 1);
        }
        else
        {
            m_rotIndex += direction;
        }
        

        Debug.Log("m_rotIndex is at " + m_rotIndex);
        m_isMoving = true;

        yield return new WaitForSeconds(m_delayTime);
        m_isMoving = false;
    }
}
