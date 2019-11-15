using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTop : MonoBehaviour
{
    public float rad;
    public Transform child;
    public bool b;
    private void OnTriggerEnter(Collider other)
    {
        if (!b)
        {
            if (other.tag == "Diceable" || other.tag == "Cuttable")
            {
                b = true;
                other.GetComponent<Transform>().transform.position = child.position;
                other.GetComponent<Transform>().transform.rotation = child.rotation;
                other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Diceable" || other.tag == "Cuttable")
        {
            other.GetComponent<Transform>().transform.position = child.position;
            other.GetComponent<Transform>().transform.rotation = child.rotation;
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Diceable" || other.tag == "Cuttable")
        {
            b = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(child.position, rad);
    }
}
