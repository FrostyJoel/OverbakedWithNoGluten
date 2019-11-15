using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSlot : MonoBehaviour
{
    public RecipeBase orderData;

    public GameObject order;
    public Text orderName;

    public void AddOrder(RecipeBase newOrder)
    {
        orderData = newOrder;
        Debug.Log("Script: OrderSlot, Method: AddOrder, Log: Added Data to Slot.");

        order.SetActive(true);
        orderName.enabled = true;
    }

    public void ClearOrder()
    {
        order.SetActive(false);
        orderName.enabled = false;

        Debug.Log("Script: OrderSlot, Method: ClearOrder, Log: Clearing order slot.");
    }
}
