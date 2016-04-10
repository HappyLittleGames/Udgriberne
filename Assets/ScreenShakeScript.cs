using UnityEngine;
using System.Collections;

public class ScreenShakeScript : MonoBehaviour {

    // Use this for initialization
    float ShakeDuration;
    float ShakeCount;
    float ShakeAmount;
    Quaternion Origin;

    void Start ()
    {
        ShakeAmount = .05f;
        Origin = transform.localRotation;
        ShakeDuration = .1f;
        ShakeCount = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(ShakeCount < ShakeDuration)
        {
            transform.localRotation = Quaternion.Euler(Random.insideUnitSphere * ShakeAmount);
        }
        else
        {
            transform.localRotation = Origin;
            //FindObjectOfType<ScreenShakeScript>().StartShake();
        }
        
	}

    void Update()
    {
        ShakeCount += Time.deltaTime;
    }

    public void StartShake()
    {
        ShakeCount = 0;
    }
}
