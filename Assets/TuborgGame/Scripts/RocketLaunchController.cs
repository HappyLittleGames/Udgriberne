using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RocketLaunchController : MonoBehaviour {

    [SerializeField] private Object m_rocketEntity;
    [SerializeField] private GameObject[] m_targetLocation = new GameObject[8];
    private int[] m_spawnLocation = new int[8];
    private bool m_rocketLaunched = false;
	
    void Start()
    {
        // Fill array with spawn locations with 45 degrees between each location
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
        if (m_rocketLaunched)
        {
            StartCoroutine(LaunchingDelay());
        }else
        {
            RandomRocketDirection();
            RocketLaunch();
        }   
	}

    IEnumerator LaunchingDelay()
    {
        float baseDelayTime = 0.5f;
        float maxDelayTime = 2.0f;
        float delayTime = Random.Range(baseDelayTime, maxDelayTime);

        yield return new WaitForSeconds(delayTime);
    }

    private int RandomRocketDirection()
    {
        int randDir = Random.Range(0, m_spawnLocation.Length);
        int newDir = m_spawnLocation[randDir];

        return newDir;
    }

    private void RocketLaunch()
    {
        m_rocketLaunched = true;
        GameObject rocketInstance = (GameObject)Instantiate(m_rocketEntity, transform.position, transform.rotation);        
    }
}
