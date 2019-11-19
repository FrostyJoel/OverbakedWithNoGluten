using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{
    public int amountOfOrders;
    public List<RecipeBase> allOrders = new List<RecipeBase>();
    [SerializeField] Order newOrder = new Order();
    private void Start()
    {
        for (int i = 0; i < allOrders.Count; i++)
        {
            newOrder.id[i] = Random.Range(0, allOrders.Count + 1);
        }
    }

    [System.Serializable]
    public struct Order
    {
        [SerializeField] public List<int> id;
    }
}

