using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yaell;

public class EindStation : MonoBehaviour
{
    [Header("Resources")]
    private Collision c;
    private OrderManager orderManagerScript;
    public GameObject scoreManagerHolder;

    [Header("Settings")]
    public RecipeBase endBaseRecipe;
    public float timeStamp;
    public bool isOnTime;
    public bool isAnOrder;

    public void Start()
    {
        scoreManagerHolder = GameObject.Find("ScoreManager");
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Carryable")
        {
            Invoke("Checker", 0.5f);
            c = col;
        }

        else if (col.transform.tag == "Unusable")
        {
            //Display "Sorry, this one is not needed!"
        }
    }

    //Wanneer tijd nul of lager is, kan je het niet meer gebruiken behalve weggooien.
    public void Checker()
    {
        if (isOnTime == false && isAnOrder == true)
        {
            c.transform.tag = "Unusable";
            scoreManagerHolder.GetComponent<ScoreManager>().Penalty();
            //Display "Sorry you weren't on time!"
        }

        else if (isOnTime == true && isAnOrder == false)
        {
            c.transform.tag = "unusable";   
            scoreManagerHolder.GetComponent<ScoreManager>().Penalty();
            //Display "Sorry, it's not for an order!"
        }
    }
}

