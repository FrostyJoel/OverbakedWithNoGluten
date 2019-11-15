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
            GameObject slices = Instantiate(diced, transform.position, Quaternion.identity);
            foreach (GameObject slice in slices.GetComponent<Item>().slices)
            {
                Vector3 randomScale = new Vector3(Random.Range(0.75f, 1.25f), Random.Range(0.75f, 1.25f), Random.Range(0.75f, 1.25f));
                Vector3 randomEuler = new Vector3(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f));
                slice.transform.localScale = randomScale;
                slice.transform.Rotate(randomEuler);
            }
            Destroy(gameObject);
        }
    }
}
