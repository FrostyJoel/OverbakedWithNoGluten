using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text time;
    public Text order;
    public Text score;
    public OrderManager orderMan;
    private void Start()
    {
        orderMan = GameObject.FindGameObjectWithTag("ReceptManager").GetComponent<OrderManager>();
    }
    // Update is called once per frame
    void Update()
    {
        time.text = "Time Left:" + "\n"+ Mathf.RoundToInt(orderMan.timer).ToString(); //Add TimeLeft
        score.text = "Score:" + "\n" + orderMan.score.ToString(); // Add Score
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
