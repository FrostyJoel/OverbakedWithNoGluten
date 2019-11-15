using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    #region Variables
    [Header("Resources")]
    public List<ItemBase> orderList = new List<ItemBase>();
    public List<ItemBase> RecipeList = new List<ItemBase>();
    public ItemBase orderData;

    [Header("Settings")]
    public int orderSlots = 6;
    public float interval = 10f;
    public float intervalRestart;
    #endregion

    //Sets restart timer.
    public void Start()
    {
        intervalRestart = interval;
    }

    public void Update()
    {
        IntervalTimer();
    }

    public void AddOrder(ItemBase orderData)
    {
        if (orderList.Count >= orderSlots)
        {
            Debug.Log("Script: OrderList, Method: AddOrder, Log: Not enough room to add Data ");
            return;
            //put some visual and audio feedback in here as well later on.
        }

        orderList.Add(orderData);
        Debug.Log("Script: OrderList, Method: AddOrder, Log: Data Added to order list");
    }

    public void RemoveOrder(ItemBase orderData)
    {
        orderList.Remove(orderData);
        Debug.Log("Script: OrderList, Method: RemoveOrder Log: Data removed from order list.");
    }

    public void IntervalTimer()
    {
        if (interval > 0)
        {
            interval -= Time.deltaTime;
        }

        else if(interval <= 0)
        {
            interval = intervalRestart;
            AddOrder(orderData);
            Debug.Log("Script: OrderList, Method: IntervalTimer, Log: Timer hit zero. Timer restart && added new order.");
        }
    }
}
