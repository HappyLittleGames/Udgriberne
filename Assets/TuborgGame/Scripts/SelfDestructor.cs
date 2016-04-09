using UnityEngine;
using System.Collections;

public class SelfDestructor : MonoBehaviour
{
    private float m_destructTime = 1f;
    public float DestructTime { set { m_destructTime = value; } }

	void Start ()
    {
        StartCoroutine(SelfDestruct(m_destructTime));
	}
	
    private IEnumerator SelfDestruct(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
