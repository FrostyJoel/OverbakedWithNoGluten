using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OrderManager : MonoBehaviour
{
    #region Variables
    [Header("Resources")]
    public List<RecipeBase> orderList = new List<RecipeBase>();
    public List<RecipeBase> RecipeList = new List<RecipeBase>();

    public RecipeBase orderData;
    public WorkingTimer orderTimer;
    AllRecipe recipes;

    [Header("Settings")]
    public int orderSlots = 6;
    public float interval = 1f;
    public float intervalRestart;

    //test
    public float reset;
    public float order1;
    public float order2;

    public bool orderOnePlaced;
    public bool orderTwoPlaced;

    public int two;
    public int one;

    public List<float> timers = new List<float>();
    //eind test
    #endregion

    //Sets restart timer.
    public void Start()
    {
        recipes = GetComponent<AllRecipe>();
        intervalRestart = interval;

        order1 = reset;
        order2 = reset;
    }

    public void Update()
    {
        IntervalTimer();
        OrderChecker();
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
        orderData.isAnOrder = true;
        orderData.isOnTime = true;

        timers.Add(order1);

        //test
        if (orderList.ElementAtOrDefault(0) != null && orderList.Count == 1)
        {
            orderOnePlaced = true;
            Debug.Log("First Order.");
        }

        else if (orderList.ElementAtOrDefault(1) != null && orderList.Count == 2)
        {
            orderTwoPlaced = true;
            Debug.Log("Second Order.");
        }

        //end test
        Debug.Log("Script: OrderList, Method: AddOrder, Log: Data Added to order list");
    }

    public void RemoveOrder(RecipeBase orderData)
    {
        orderList.RemoveAt(one);
        Debug.Log("Script: OrderList, Method: RemoveOrder Log: Data removed from order list.");
    }

    public void IntervalTimer()
    {
        if (interval > 0)
        {
            interval -= Time.deltaTime;
        }

        else if (interval <= 0)
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

    public void OrderChecker()
    {
        if (orderOnePlaced)
        {
            order1 -= Time.deltaTime;

            if (order1 <= 0)
            {
                RemoveOrder(orderData);
                orderOnePlaced = false;
                order1 = reset;
            }
        }

        if (orderTwoPlaced)
        {
            order2 -= Time.deltaTime;

            if (order2 <= 0)
            {
                RemoveOrder(orderData);
                orderTwoPlaced = false;
                order2 = reset;
            }
        }
    }
}
