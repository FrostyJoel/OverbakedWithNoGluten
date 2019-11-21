using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : WorkStation
{
    public void ChangeRecipe(RecipeBase recept)
    {
        availableRecipe = recept;
    }
}
