using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public RaycastHit hit;
    public float force;
    public float completionAmount;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cuttable")
        {
            Vector3 cuttingForce = new Vector3(other.transform.localPosition.x,0, 0);
            other.GetComponent<Rigidbody>().AddForce(cuttingForce * force);
        }
        if(other.gameObject.tag == "Diceable")
        {
            other.GetComponent<Diced>().percentage += completionAmount;
        }
    }

}
