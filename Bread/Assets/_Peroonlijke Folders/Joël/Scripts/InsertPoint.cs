using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertPoint : MonoBehaviour
{
    public Collider nonTrigger;
    [SerializeField]WorkStation parentWorkstation;
    private void Start()
    {
        parentWorkstation = GetComponentInParent<WorkStation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ingriedients")
        {
            parentWorkstation.inStation.Add(other.GetComponent<Item>().currentItem);
            parentWorkstation.CheckRecipe();
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        if (mesh.enabled == true)
        {
            nonTrigger.enabled = true;
        }
        else
        {
            nonTrigger.enabled = false;
        }
    }
}
