using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
public class ItemBase : ScriptableObject
{
    [SerializeField] public int id;
    [SerializeField] public GameObject item;
}
