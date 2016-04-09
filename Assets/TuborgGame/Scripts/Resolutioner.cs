using UnityEngine;
using System.Collections;

public class Resolutioner : MonoBehaviour
{
    [SerializeField] private int m_xResolution = 800;
    [SerializeField] private int m_yResolution = 800;
    [SerializeField] private bool m_fullScreen = false;

    void Start ()
    {
        Screen.SetResolution(m_xResolution, m_yResolution, m_fullScreen);
	}
	

}
