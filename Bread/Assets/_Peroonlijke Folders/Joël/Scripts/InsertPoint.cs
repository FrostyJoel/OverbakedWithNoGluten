using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertPoint : MonoBehaviour
{
    [SerializeField]WorkStation parentWorkstation;
    private void Start()
    {
        parentWorkstation = GetComponentInParent<WorkStation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diced" || other.gameObject.tag == "Cut")
        {
            parentWorkstation.inStation.Add(other.GetComponent<Item>().currentItem);
            parentWorkstation.CheckRecipe();
            Destroy(other.gameObject);
        }
    }
}
