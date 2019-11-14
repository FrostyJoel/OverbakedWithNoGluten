using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe",menuName = "RecipeList")]
public class RecipeBase : ScriptableObject
{
    public List<ItemBase> recipe = new List<ItemBase>();
    public ItemBase finalProduct;
}
