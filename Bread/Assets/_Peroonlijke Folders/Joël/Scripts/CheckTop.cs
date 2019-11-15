using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTop : MonoBehaviour
{
    public float rad;
    public Transform child;
    public bool b;
    // Update is called once per frame
    void Update()
    {
        Collider[] c = Physics.OverlapSphere(child.position, rad);
        for (int i = 0; i < c.Length; i++)
        {
            if(c[i].tag == "Diceable" || c[i].tag == "Cuttable")
            {
                c[i].GetComponent<Transform>().transform.position = child.position;
                c[i].GetComponent<Transform>().transform.rotation = child.rotation;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(child.position, rad);
    }
}
