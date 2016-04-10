using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RocketLaunchController : MonoBehaviour {

    [SerializeField] private float m_difficultyRampTime;
    [SerializeField] private GameObject m_spawnPoint;
    [SerializeField] private Object[] m_rocketEntity = new Object[2];
    private int[] m_spawnLocation = new int[8];
    [SerializeField] private float m_delayTime = 1.5f;
    private float m_currentTime = 0;
	
    void Start()
    {
        for (int i = 0; i < m_spawnLocation.Length; i++)
        {
            if (i != 0)
            {
                m_spawnLocation[i] = m_spawnLocation[i-1] + 360 / 8;
            }
            else
            {
                m_spawnLocation[i] = 360 / 8;
            }
        }
    }

	void FixedUpdate () {        
        if (m_currentTime < m_delayTime)
        {
            m_currentTime += Time.fixedDeltaTime;
        }else
        {
            RocketLaunch();
            m_currentTime = 0;
            m_delayTime = Mathf.Clamp((m_delayTime * 0.95f), 0.05f, 10f);
        }
    }

    private int RandomRocketDirection()
    {
        int randDir = Random.Range(0, m_spawnLocation.Length);
        int newDir = m_spawnLocation[randDir];

        return newDir;
    }

    private void RocketLaunch()
    {
        int rocketDirection = RandomRocketDirection();
        
        gameObject.transform.Rotate(new Vector3(0, 0, rocketDirection));

        int rocketRand = Random.Range(0, m_rocketEntity.Length);
        GameObject rocketInstance = (GameObject)Instantiate(m_rocketEntity[rocketRand], m_spawnPoint.transform.position, transform.rotation);

        rocketInstance.GetComponent<RocketController>().DestroyTime = 5f;

        if (Time.timeSinceLevelLoad > m_difficultyRampTime)
        {
            float torqueForce = 50;
            int strangeRocket = Random.Range(0, 2);
            if (strangeRocket == 0)
            {
                rocketInstance.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, (torqueForce * Random.Range(-1, 1))));
            }
        }
    }
}
