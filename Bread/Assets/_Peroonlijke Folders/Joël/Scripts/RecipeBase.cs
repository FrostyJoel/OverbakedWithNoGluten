using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "RecipeList")]
public class RecipeBase : ScriptableObject
{
    public List<ItemBase> recipe = new List<ItemBase>();
    public FinishedItemBase finalProduct;
    public int id;

    //Yaell
    public bool isOnTime;
    public bool isAnOrder;

    public bool isSmall;
    public bool isMedium;
    public bool isBig;
}
