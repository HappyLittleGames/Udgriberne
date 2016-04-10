using UnityEngine;
using System.Collections;

public class MaintainRotation : MonoBehaviour {

    private Quaternion m_originalRot;

	void Start ()
    {
        m_originalRot = transform.rotation;
	}
	

	void LateUpdate()
    {
        transform.rotation = m_originalRot;
	}
}
