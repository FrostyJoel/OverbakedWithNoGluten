using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text time;
    public Text order;
    public Text score;
    public Color minusScore;
    public OrderManager orderMan;
    private void Start()
    {
        orderMan = GameObject.FindGameObjectWithTag("ReceptManager").GetComponent<OrderManager>();
    }
    // Update is called once per frame
    void Update()
    {
        int currentTime = Mathf.RoundToInt(orderMan.timer);
        int currentScore = Mathf.RoundToInt(orderMan.score);
        time.text = "Time Left:" + "\n"+ currentTime.ToString(); //Add TimeLeft
        if (orderMan.timer <= 0 && orderMan.orderList.Count > 0)
        {
            score.color = minusScore;
        }
        else
        {
            score.color = Color.black;
        }
        score.text = "Score:" + "\n" + currentScore.ToString(); // Add Score
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
