using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    #region Variables
    [Header("Resources")]
    public List<RecipeBase> orderList = new List<RecipeBase>();
    public List<RecipeBase> RecipeList = new List<RecipeBase>();
    public RecipeBase orderData;
    AllRecipe recipes;

    [Header("Settings")]
    public int orderSlots = 6;
    public float interval = 10f;
    public float intervalRestart;
    #endregion

    //Sets restart timer.
    public void Start()
    {
        recipes = GetComponent<AllRecipe>();
        intervalRestart = interval;
    }

    public void Update()
    {
        IntervalTimer();
    }

    public void AddOrder(RecipeBase orderData)
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

    public void RemoveOrder(RecipeBase orderData)
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
            int randomOrder = Random.Range(1, recipes.allRecipes.Count + 1);
            Debug.Log(randomOrder);
            for (int i = 0; i < recipes.allRecipes.Count; i++)
            {
                if (recipes.allRecipes[i].id == randomOrder)
                {
                    orderData = recipes.allRecipes[i];
                    break;
                }
            }
            AddOrder(orderData);
            Debug.Log("Script: OrderList, Method: IntervalTimer, Log: Timer hit zero. Timer restart && added new order.");
        }
    }
}
