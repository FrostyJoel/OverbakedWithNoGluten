using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float force;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cuttable")
        {
            Vector3 cuttingForce = new Vector3(other.transform.position.x,0, 0);
            other.GetComponent<Rigidbody>().AddForce(cuttingForce * force);
        }
    }
}
