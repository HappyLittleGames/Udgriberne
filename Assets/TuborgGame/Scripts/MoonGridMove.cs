using UnityEngine;
using System.Collections;

public class MoonGridMove : MonoBehaviour {

    private int m_GridNo = 8;
    public int GridNo
    {
        get { return m_GridNo; }
        set { m_GridNo = value; }
    }

    [SerializeField]
    [Range(0f, 50f)]
    private float m_GridSize;
    public float GridSize
    {
        get { return m_GridSize; }
        set { m_GridSize = value; }
    }

    int MoonDir = 0;

    void Start()
    {
        GridSize = 360 / GridNo;
    }

    int GetInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        { MoonDir = -1; }

        else if (Input.GetKey(KeyCode.LeftArrow))
        { MoonDir = 1; }

        else
        { MoonDir = 0; }

        return MoonDir;
    }

    float MoveCooldown = 1;

    void FixedUpdate()
    {
        Vector3 CurrRotation = transform.rotation.eulerAngles;
        Vector3 DesiredRotation = new Vector3();
        
        transform.rotation = Quaternion.Euler(CurrRotation.x, CurrRotation.y, Mathf.Lerp(transform.rotation.z, GetInput() * GridSize, Time.time * 20));
        

        //transform.Rotate(DesiredRotation);

        if (CurrRotation != DesiredRotation)
            MoveCooldown = 0;
        MoveCooldown += Time.deltaTime;
        
    }

}
