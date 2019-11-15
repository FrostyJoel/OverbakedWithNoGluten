using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : MonoBehaviour
{
    public AllRecipe receptManager;
    public GameObject point;
    public GameObject finishedProduct;
    public List<ItemBase> inStation = new List<ItemBase>();
    public RecipeBase availableRecipe;
    public bool cooking;
    public bool finished;
    public float cookingTime;
    public float offset;
    RaycastHit hit;
    [SerializeField]float currentTime;

    public void CheckRecipe()
    {
        foreach (RecipeBase recipe in receptManager.stoveRecipe)
        {
            if(inStation.Count == recipe.recipe.Count)
            {
                bool b = false;
                for (int i = 0; i < inStation.Count; i++)
                {
                    if(inStation[i] == recipe.recipe[i])
                    {
                        b = true;
                    }
                    else
                    {
                        b = false;
                        break;
                    }
                }
                if (b)
                {
                    availableRecipe = recipe;
                    cooking = true;
                    currentTime = cookingTime;
                }
            }
        }
    }

    private void Update()
    {
        if (cooking && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        if(cooking || finished)
        {
            point.SetActive(false);
        }
        if (cooking && currentTime <= 0)
        {
            Vector3 endPosition = new Vector3(finishedProduct.transform.position.x, finishedProduct.transform.position.y+ offset, finishedProduct.transform.position.z);
            Instantiate(availableRecipe.finalProduct.item,endPosition,Quaternion.identity);
            inStation.Clear();
            finished = false;
            availableRecipe = null;
            cooking = false;
            point.SetActive(true);
        }
    }
    
}
