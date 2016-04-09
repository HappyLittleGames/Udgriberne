using UnityEngine;
using System.Collections;

public class MoonControllerHeight : MonoBehaviour {

    [SerializeField]
    [Range(0f, 10f)]
    private float m_Speed = 0.5f;
    public float Speed
    {
        get { return m_Speed; }
        set { m_Speed = value; }
    }
    [SerializeField]
    [Range(0f, 10f)]
    private float m_MinHeight = 2;
    public float MinHeight
    {
        get { return m_MinHeight; }
        set { m_MinHeight = value; }
    }
    [SerializeField]
    [Range(0f, 50)]
    private float m_MaxHeight = 20;
    public float MaxHeight
    {
        get { return m_MaxHeight; }
        set { m_MaxHeight = value; }
    }

    int MoonHeight = 0;

    /*
    void Start()
    {
        GetComponentInParent<MoonController>().SpeedMod = -transform.localPosition.y;
    }*/

    int GetInput()
    {
        if (Input.GetKey(KeyCode.DownArrow) && transform.localPosition.y > MinHeight)
        {
            MoonHeight = -1;
            //GetComponentInParent<MoonController>().SpeedMod = -transform.localPosition.y;
        }

        else if (Input.GetKey(KeyCode.UpArrow) && transform.localPosition.y < MaxHeight)
        {
            MoonHeight = 1;
            //GetComponentInParent<MoonController>().SpeedMod = -transform.localPosition.y;
        }

        else
        { MoonHeight = 0; }

        return MoonHeight;
    }

    void FixedUpdate()
    {
        transform.localPosition += new Vector3(0, GetInput() * Speed, 0);
    }

}
