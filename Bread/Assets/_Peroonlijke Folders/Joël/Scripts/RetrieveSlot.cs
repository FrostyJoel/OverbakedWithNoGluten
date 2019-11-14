using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieveSlot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Plate")
        {
            if (GetComponentInParent<WorkStation>().finished)
            {
                if (!other.GetComponent<Plate>().filled)
                {
                    other.GetComponent<Plate>().filled = true;
                    other.GetComponent<Plate>().fil.SetActive(true);
                    //other.GetComponent<Plate>().holdingItem = GetComponentInParent<WorkStation>().finishedProduct;
                }
            }
        }
    }
}
