using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text time;
    public Text order;
    public OrderManager orderMan;
    private void Start()
    {
        orderMan = GameObject.FindGameObjectWithTag("ReceptManager").GetComponent<OrderManager>();
    }
    // Update is called once per frame
    void Update()
    {
        time.text = "Time Left: "; //Add TimeLeft
        if(orderMan.orderList.Count > 0)
        {
            order.text = "Next Order: " + "\n" + orderMan.orderList.Peek().name.ToString();
        }
        else
        {
            order.text = "Next Order: " + "\n" + "No Orders";
        }
    }
}
