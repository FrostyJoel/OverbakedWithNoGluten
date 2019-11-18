using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Resources")]
    public RecipeBase recipeBase;
    private AllRecipe recipeList;

    [Header("Settings")]
    public int currentScore;
    public int penalty = -2;
    public int addedScore = 0;

    public int smallScore = 2;
    public int mediumScore = 5;
    public int bigScore = 8;

    public void Start()
    {
        // recipeBase = GameObject.Find("OrderManager").GetComponent<OrderManager>().orderData;
        recipeList = GameObject.Find("OrderManager").GetComponent<AllRecipe>();
        currentScore = 0;
    }

    public void AddScore()
    {
        if (recipeBase.isSmall)
        {
            addedScore = smallScore;
        }

        else if (recipeBase.isMedium)
        {
            addedScore = mediumScore;
        }

        else if (recipeBase.isBig)
        {
            addedScore = bigScore;
        }

        currentScore += addedScore;
    }

    public void Penalty()
    {
        currentScore -= penalty;
    }
}
