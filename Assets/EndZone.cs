using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour
{
    void OnTriggerExit (Collider coll)
    {
        if(coll.gameObject.GetComponent<RocketController>())
            //if(coll.gameObject.GetComponent<RocketController>().)
        Debug.Log("Death");
    }
	
}
