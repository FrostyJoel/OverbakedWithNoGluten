using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    public Transform parent;
    OrderManager orders;
    OrderSlot[] slots;

    void Start()
    {
        orders = GameObject.Find("Order Manager").GetComponent<OrderManager>();
        slots = parent.GetComponentsInChildren<OrderSlot>();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < orders.orderList.Count)
            {
                //slots[i].AddOrder(orders.orderList.);
            }

            else
            {
                slots[i].ClearOrder();
            }
        }          
        Debug.Log("Script: UIUpdater, Method: UpdateUI, Log: Updated UI.");
    }
}
