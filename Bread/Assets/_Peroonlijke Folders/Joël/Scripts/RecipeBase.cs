﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "RecipeList")]
public class RecipeBase : ScriptableObject
{
    public List<ItemBase> recipe = new List<ItemBase>();
    public FinishedItemBase finalProduct;
    public int id;
    public float orderTime;
    public float score;
}
