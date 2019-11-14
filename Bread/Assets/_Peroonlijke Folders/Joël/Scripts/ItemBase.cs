using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
public class ItemBase : ScriptableObject
{
    [SerializeField] public ItemStats stats = new ItemStats();
    [SerializeField] public GameObject item;

    [System.Serializable]
    public struct ItemStats
    {
        [SerializeField] int id;
    }
}
