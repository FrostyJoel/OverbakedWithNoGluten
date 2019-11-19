using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    OrderManager order;
    public float force;

    private void Start()
    {
        order = GameObject.FindGameObjectWithTag("ReceptManager").GetComponent<OrderManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finished")
        {
            if (order.orderList.Peek().id == other.GetComponent<FinishedProduct>().finished.id)
            {
                order.TimeChecker();
            }
            else
            {
                other.attachedRigidbody.velocity += transform.up * force;
            }
        }
        else
        {
            other.attachedRigidbody.velocity += transform.up * force;
        }
    }
}
