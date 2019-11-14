using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diced : MonoBehaviour
{
    public GameObject diced;
    public float percentage;
    public float maxDice;

    private void Update()
    {
        if(percentage >= maxDice)
        {
            Instantiate(diced, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
