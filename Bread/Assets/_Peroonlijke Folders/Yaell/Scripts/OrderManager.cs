using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OrderManager : MonoBehaviour
{
    #region Variables
    [Header("Resources")]
    public Queue<RecipeBase> orderList = new Queue<RecipeBase>();
    //public List<RecipeBase> RecipeList = new List<RecipeBase>();

    public Collider endPoint;
    public RecipeBase orderData;
    public WorkingTimer orderTimer;
    public FinishedItemBase tempProduct;
    AllRecipe recipes;

    [Header("Settings")]
    public int orderSlots = 6;
    public float interval = 1f;
    public float intervalRestart;
    public float score = 0;
    public float maximumMinusTime;
    //test
    public float reset;
    public float orderTime;
    public float timer;
    //eind test
    #endregion

    //Sets restart timer.
    public void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("EndPoint").GetComponent<SphereCollider>();
        recipes = GetComponent<AllRecipe>();
        intervalRestart = interval;
    }

    public void Update()
    {
        IntervalTimer();
        if(orderList.Count > 0)
        {
            OrderChecker();
            endPoint.enabled = true;
        }
        else
        {
            endPoint.enabled = false;
        }
    }

    public void AddOrder(RecipeBase orderData)
    {
        if (orderList.Count >= orderSlots)
        {
            //Debug.Log("Script: OrderList, Method: AddOrder, Log: Not enough room to add Data ");
            return;
            //put some visual and audio feedback in here as well later on.
        }
        orderList.Enqueue(orderData);
        Debug.Log(orderList.Count());
        Debug.Log(orderList.Last());
        //Debug.Log("Script: OrderList, Method: AddOrder, Log: Data Added to order list");
    }

    public void RemoveOrder()
    {
        Debug.Log("Correct Item");
        orderList.Dequeue();
        //Debug.Log("Script: OrderList, Method: RemoveOrder Log: Data removed from order list.");
    }

    public void IntervalTimer()
    {
        if (interval > 0 && orderList.Count < orderSlots)
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
            //Debug.Log("Script: OrderList, Method: IntervalTimer, Log: Timer hit zero. Timer restart && added new order.");
        }
    }

    public void OrderChecker()
    {
        if (orderList.Count > 0)
        {
            if(timer > maximumMinusTime)
            {
                timer -= Time.deltaTime;
            }
        }
    }
    public void TimeChecker()
    {
        if (timer > 0)
        {
            
        }
        if (timer < 0)
        {
            //Remove points
        }
        RemoveOrder();
    }
}
