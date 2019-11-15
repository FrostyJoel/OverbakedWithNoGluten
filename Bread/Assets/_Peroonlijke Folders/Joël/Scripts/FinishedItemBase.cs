using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Product", menuName = "ProductList")]
public class FinishedItemBase : ScriptableObject
{
    [SerializeField] public FinishedItemStats stats = new FinishedItemStats();
    [SerializeField] public GameObject item;

    [System.Serializable]
    public struct FinishedItemStats
    {
        [SerializeField] int id;
    }
}
